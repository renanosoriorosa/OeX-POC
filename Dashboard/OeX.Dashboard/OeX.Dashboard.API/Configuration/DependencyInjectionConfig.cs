using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using OeX.Auth.Domain.Common;
using OeX.Dashboard.API.Extensions;
using OeX.Dashboard.API.Interfaces;
using OeX.Dashboard.Application.Notificacoes;
using OeX.Dashboard.Application.Notificacoes.Interfaces;
using OeX.Dashboard.Domain.Empresas.Interfaces;
using OeX.Dashboard.Infrastructure.Context;
using OeX.Dashboard.Infrastructure.Repository.Empresas;
using OeX.Dashboard.Infrastructure.UoW;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OeX.Dashboard.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<RNContext>();

            services.AddScoped<AuthenticationService>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
