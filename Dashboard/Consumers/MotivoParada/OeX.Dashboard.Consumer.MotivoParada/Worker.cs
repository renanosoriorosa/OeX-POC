using Microsoft.Extensions.Options;
using OeX.Dashboard.Application.Extensions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace OeX.Dashboard.Consumer.MotivoParada
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IConnection? _connection;
        private IModel? _channel;
        private readonly RabbitMQSettings _rabbitMQSettings;

        public Worker(ILogger<Worker> logger,
            IOptions<RabbitMQSettings> options)
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
            //_channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
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
                        Console.WriteLine($"received");
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        // Chama o método assíncrono de forma bloqueante
                        ProcessMessageAsync(message).GetAwaiter().GetResult();
                        Console.WriteLine($"processed");

                        // Confirmação manual da mensagem (ACK)
                        _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
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

        private async Task ProcessMessageAsync(string message)
        {
            Console.WriteLine("processing...");
            await Task.Delay(5000); // Simula processamento assíncrono
            Console.WriteLine($"[x] Processamento finalizado para: {message}");
        }

        public override void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
            base.Dispose();
        }
    }
}
