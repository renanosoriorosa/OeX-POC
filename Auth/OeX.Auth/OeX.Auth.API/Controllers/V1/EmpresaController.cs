using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OeX.Auth.API.Interfaces;
using OeX.Auth.Application.Empresas.Commands.Create;
using OeX.Auth.Application.Notificacoes.Interfaces;

namespace OeX.Auth.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class EmpresaController : MainController
    {
        private readonly IMediator _mediator;

        public EmpresaController(INotificador notificador, IUser appUser, IMediator mediator) : base(notificador, appUser)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateEmpresaCommand command)
        {
            try
            {
                return CustomResponse(await _mediator.Send(command));
            }
            catch (Exception e)
            {
                return SendExceptionRequest<bool>(e);
            }
        }
    }
}
