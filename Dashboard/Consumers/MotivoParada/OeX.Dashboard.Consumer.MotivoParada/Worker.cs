using MediatR;
using Microsoft.Extensions.Options;
using OeX.Dashboard.Application.Base;
using OeX.Dashboard.Application.Extensions;
using OeX.Dashboard.Application.MotivosParadas.Commands;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OeX.Dashboard.Consumer.MotivoParada
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IConnection? _connection;
        private IModel? _channel;
        private readonly IServiceProvider _serviceProvider;
        private readonly RabbitMQSettings _rabbitMQSettings;

        public Worker(ILogger<Worker> logger,
            IOptions<RabbitMQSettings> options,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _rabbitMQSettings = options.Value;

            var factory = new ConnectionFactory()
            {
                HostName = _rabbitMQSettings.Host, // Endereço do servidor RabbitMQ
                UserName = _rabbitMQSettings.User,    // Usuário padrão
                Password = _rabbitMQSettings.Password      // Senha padrão
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumer = new EventingBasicConsumer(_channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        
                        // Chama o método assíncrono de forma bloqueante
                        var result = ProcessMessageAsync(message).GetAwaiter().GetResult();

                        if (result.Success)
                        {
                            // Confirmação manual da mensagem (ACK)
                            _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                        }
                        else
                        {
                            if(result.Messages is not null)
                            {
                                foreach (var error in result.Messages)
                                    _logger.LogError(error);
                            }

                            if (result.Exception is not null)
                            {
                                _logger.LogError(result.Exception.Message);
                                _logger.LogError(result.Exception.InnerExceptionMessage ?? "");
                                _logger.LogError(result.Exception.StackTrace ?? "");
                            }
                        }
                    };
                    _channel.BasicConsume(queue: _rabbitMQSettings.QueueMotivoParada,
                                          autoAck: false,
                                          consumer: consumer);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro no consumidor RabbitMQ");
                    await Task.Delay(5000, stoppingToken); // Aguarda 5 segundos antes de tentar novamente
                }
            }
        }

        private async Task<Result<bool>> ProcessMessageAsync(string message)
        {
            using (var scope = _serviceProvider.CreateScope()) // Criando um escopo manualmente
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>(); // Resolve o IMediator no escopo

                try
                {
                    var motivoParadaCommand = JsonSerializer.Deserialize<CreateEditMotivoParadaCommand>(message);

                    return await mediator.Send(motivoParadaCommand!);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao processar mensagem da fila");
                    return Result<bool>.FailException(ex);
                }
            }
        }

        public override void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
            base.Dispose();
        }
    }
}
