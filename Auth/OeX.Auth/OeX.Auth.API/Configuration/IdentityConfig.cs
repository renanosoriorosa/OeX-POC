using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OeX.Auth.API.Extensions;
using OeX.Auth.Domain.Usuarios;
using OeX.Auth.Infrastructure.Context;

namespace OeX.Auth.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppTokenSettings");
            services.Configure<AppTokenSettings>(appSettingsSection);

            services.AddIdentity<Usuario, IdentityRole>()
                .AddEntityFrameworkStores<RNContext>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
