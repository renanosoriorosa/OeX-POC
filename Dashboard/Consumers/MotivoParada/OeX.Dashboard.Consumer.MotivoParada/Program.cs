using OeX.Dashboard.Application.Extensions;
using OeX.Dashboard.Consumer.MotivoParada;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var RabbitMQSettingsSection = builder.Configuration.GetSection("RabbitMQ");
builder.Services.Configure<RabbitMQSettings>(RabbitMQSettingsSection);

var host = builder.Build();
host.Run();
