using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using OeX.Auth.Application.Base;
using OeX.Auth.Application.Extensions;
using System.Net;
using System.Text;
using System.Text.Json;

namespace OeX.Auth.Application.Empresas.Commands.Create
{
    public class CreateEmpresaDashboardCommandHandler : IRequestHandler<CreateEmpresaDashboardCommand, Result<bool>>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApiDashboardSettings _apiDashboardSettings;

        public CreateEmpresaDashboardCommandHandler(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IOptions<ApiDashboardSettings> options)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _apiDashboardSettings = options.Value;
        }

        public async Task<Result<bool>> Handle(CreateEmpresaDashboardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var empresaJson = JsonSerializer.Serialize(request);
                var content = new StringContent(empresaJson, Encoding.UTF8, "application/json");

                // Pega o token JWT do usuário logado do contexto HTTP
                //string token = GetTokenFromHttpContext();

                // Consumir a API 1
                var ApiDashboard = _httpClientFactory.CreateClient("ApiDashboard");
                //ApiDashboard.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await ExecuteApiCallAsync<bool>(
                                                ApiDashboard,
                                                content,
                                                cancellationToken,
                                                _apiDashboardSettings.UrlCreateEmpresa);

                if (response.Success)
                    return Result<bool>.Ok(true);

                if (response.Exception is not null)
                    return Result<bool>.FailException(response.Exception);

                return Result<bool>.Fail(response.Messages!);
            }
            catch (Exception e)
            {
                return Result<bool>.FailException(e);
            }
        }

        private string GetTokenFromHttpContext()
        {
            // Tenta obter o token JWT do cabeçalho Authorization
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (authorizationHeader.Count > 0)
            {
                var token = authorizationHeader.ToString().Replace("Bearer ", "");
                return token;
            }

            return "";
        }

        private async Task<Result<T>> ExecuteApiCallAsync<T>(
            HttpClient client,
            StringContent content,
            CancellationToken cancellationToken,
            string url)
        {
            // Realiza a requisição POST
            var response = await client.PostAsync(url, content, cancellationToken);

            if (response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.BadRequest)
                throw new Exception("O sistema está fora por enquanto, aguarde e tente novamente.");

            // Lê o conteúdo da resposta como string
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserializa o JSON para o tipo Result<T>
            var result = JsonSerializer.Deserialize<Result<T>>(jsonResponse);

            // Se a deserialização falhar, retorna um Result de falha
            return result ?? Result<T>.Fail("Falha ao converter objeto.");
        }
    }
}
