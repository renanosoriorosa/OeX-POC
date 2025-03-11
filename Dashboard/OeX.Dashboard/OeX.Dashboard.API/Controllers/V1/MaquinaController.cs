using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OeX.Dashboard.API.Interfaces;
using OeX.Dashboard.Application.Maquinas.Queries;
using OeX.Dashboard.Application.Notificacoes.Interfaces;

namespace OeX.Dashboard.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class MaquinaController : MainController
    {
        private readonly IMediator _mediator;

        public MaquinaController(INotificador notificador, IUser appUser, IMediator mediator) : base(notificador, appUser)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetParaSelectFiltro()
        {
            try
            {
                return CustomResponse(await _mediator.Send(new GetMaquinasParaSelectFiltroQuery()));
            }
            catch (Exception e)
            {
                return SendExceptionRequest<bool>(e);
            }
        }
    }
}
