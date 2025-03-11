using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using OeX.Management.API.Extensions;
using OeX.Management.API.Interfaces;
using OeX.Management.Domain.Common;
using OeX.Management.Domain.Empresas.Interfaces;
using OeX.Management.Infrastructure.Context;


using Swashbuckle.AspNetCore.SwaggerGen;
using OeX.Management.API.Configuration;
using OeX.Management.Domain.MotivosParada.Interfaces;
using OeX.Management.Infrastructure.Repository.MotivosParada;

namespace OeX.Auth.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<RNContext>();
       
            services.AddScoped<IUser, AspNetUser>();
  

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddScoped<IMotivoParadaRepository, MotivoParadaRepository>();

            return services;
        }
    }
}
