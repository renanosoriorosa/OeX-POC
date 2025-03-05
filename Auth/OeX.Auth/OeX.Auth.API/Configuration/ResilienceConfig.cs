using OeX.Auth.Application.Extensions;
using Polly;

namespace OeX.Auth.API.Configuration
{
    public static class ResilienceConfig
    {
        public static IServiceCollection AddResiliencePolicies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var apiDashboardSettingsSection = configuration.GetSection("ApiDashboard");
            services.Configure<ApiDashboardSettings>(apiDashboardSettingsSection);

            var apiDashboardSettings = apiDashboardSettingsSection
                                        .Get<ApiDashboardSettings>();

            // Configuração do HttpClient para Dashboard com Polly
            services.AddHttpClient("ApiDashboard", client =>
            {
                client.BaseAddress = new Uri(apiDashboardSettings!.UrlBase);
            })
            .AddPolicyHandler(GetRetryPolicy())        // Adiciona a política de Retry
            .AddPolicyHandler(GetCircuitBreakerPolicy()); // Adiciona a política de Circuit Breaker


            var apiManagementSettingsSection = configuration.GetSection("ApiManagement");
            services.Configure<ApiManagementSettings>(apiManagementSettingsSection);

            var apiManagementSettings = apiManagementSettingsSection
                                        .Get<ApiManagementSettings>();

            // Configuração do HttpClient para Managament com Polly
            services.AddHttpClient("ApiManagament", client =>
            {
                client.BaseAddress = new Uri(apiManagementSettings!.UrlBase);
            })
            .AddPolicyHandler(GetRetryPolicy())        // Adiciona a política de Retry
            .AddPolicyHandler(GetCircuitBreakerPolicy()); // Adiciona a política de Circuit Breaker

            return services;
        }

        // Política de Retry com Exponential Backoff
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return Policy.HandleResult<HttpResponseMessage>(r =>
                            (int)r.StatusCode >= 500 || // Erros 5xx
                            (int)r.StatusCode >= 400 && (int)r.StatusCode != 400 && (int)r.StatusCode != 401 && (int)r.StatusCode != 403 // Erros 4xx (exceto 400, 401, 403)
                          ) // Política para falhas
                         .WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(5)); // 3 tentativas com 5 segundos de intervalo
        }

        // Política de Circuit Breaker
        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return Policy.HandleResult<HttpResponseMessage>(r =>
                            (int)r.StatusCode >= 500 || // Erros 5xx
                            (int)r.StatusCode >= 400 && (int)r.StatusCode != 400 && (int)r.StatusCode != 401 && (int)r.StatusCode != 403 // Erros 4xx (exceto 400, 401, 403)
                          ) // Política para falhas
                         .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30)); // 3 falhas consecutivas abre o circuito por 30 segundos
        }
    }
}
