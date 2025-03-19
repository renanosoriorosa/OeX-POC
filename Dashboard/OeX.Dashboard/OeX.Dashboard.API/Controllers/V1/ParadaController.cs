using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OeX.Dashboard.API.Interfaces;
using OeX.Dashboard.Application.Maquinas.Queries;
using OeX.Dashboard.Application.Notificacoes.Interfaces;
using OeX.Dashboard.Application.OrdensProducao.Queries;
using OeX.Dashboard.Application.Paradas.Queries;

namespace OeX.Dashboard.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class ParadaController : MainController
    {
        private readonly IMediator _mediator;

        public ParadaController(INotificador notificador, IUser appUser, IMediator mediator) : base(notificador, appUser)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountTotalByMonth(int month, int idMaquina)
        {
            try
            {
                return CustomResponse(await _mediator.Send(new GetCountTotalParadaQuery(month, idMaquina)));
            }
            catch (Exception e)
            {
                return SendExceptionRequest<int>(e);
            }
        }
    }
}
