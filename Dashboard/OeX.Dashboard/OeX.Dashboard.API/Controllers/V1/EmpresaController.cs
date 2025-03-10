using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OeX.Dashboard.API.Interfaces;
using OeX.Dashboard.Application.Empresas.Commands;
using OeX.Dashboard.Application.Notificacoes.Interfaces;

//teste yur
namespace OeX.Dashboard.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/integracao/v{version:apiVersion}/[controller]/[action]")]
    public class EmpresaController : MainController
    {
        private readonly IMediator _mediator;

        public EmpresaController(INotificador notificador, IUser appUser, IMediator mediator) : base(notificador, appUser)
        {
            _mediator = mediator;
        }

        [HttpPost]
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
