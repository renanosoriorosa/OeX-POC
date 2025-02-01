using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using OeX.Auth.API.Extensions;
using OeX.Auth.API.Interfaces;
using OeX.Auth.Application.Notificacoes;
using OeX.Auth.Application.Notificacoes.Interfaces;
using OeX.Auth.Infrastructure.Context;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OeX.Auth.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<RNContext>();

            services.AddScoped<AuthenticationService>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
