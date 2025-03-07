using OeX.Dashboard.Domain.Common;
using OeX.Dashboard.Application.Extensions;
using OeX.Dashboard.Application.Notificacoes;
using OeX.Dashboard.Application.Notificacoes.Interfaces;
using OeX.Dashboard.Consumer.MotivoParada;
using OeX.Dashboard.Domain.Empresas.Interfaces;
using OeX.Dashboard.Domain.MotivosParada.Interfaces;
using OeX.Dashboard.Infrastructure.Context;
using OeX.Dashboard.Infrastructure.Repository.Empresas;
using OeX.Dashboard.Infrastructure.Repository.MotivoParadaRepository;
using OeX.Dashboard.Infrastructure.UoW;
using OeX.Dashboard.Application.Empresas.Commands;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var RabbitMQSettingsSection = builder.Configuration.GetSection("RabbitMQ");
builder.Services.Configure<RabbitMQSettings>(RabbitMQSettingsSection);

builder.Services.AddScoped<RNContext>();
builder.Services.AddScoped<INotificador, Notificador>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IMotivoParadaRepository, MotivoParadaRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateEmpresaCommandHandler).Assembly));

var host = builder.Build();
host.Run();
