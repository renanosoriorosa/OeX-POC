using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OeX.Dashboard.API.Interfaces;
using OeX.Dashboard.Application.IndicadoresMensais.Queries;
using OeX.Dashboard.Application.Manutencoes.Queries;
using OeX.Dashboard.Application.Notificacoes.Interfaces;
using OeX.Dashboard.Domain.Indicadores.Enums;

namespace OeX.Dashboard.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class ManutencaoController : MainController
    {
        private readonly IMediator _mediator;

        public ManutencaoController(INotificador notificador, IUser appUser, IMediator mediator) : base(notificador, appUser)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountTotalByMonth(int month, int year, int idMaquina)
        {
            try
            {
                return CustomResponse(await _mediator.Send(new GetCountTotalManutencaoQuery(month, year, idMaquina)));
            }
            catch (Exception e)
            {
                return SendExceptionRequest<int>(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMTTRByMonth(int month, int year, int idMaquina)
        {
            try
            {
                return CustomResponse(await _mediator.Send(
                        new GetIndicadorByMonthAndMaquinaQuery(
                                month,
                                year,
                                idMaquina,
                                IndicadorEnum.MTTR)));
            }
            catch (Exception e)
            {
                return SendExceptionRequest<int>(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMTBFMonth(int month, int year, int idMaquina)
        {
            try
            {
                return CustomResponse(await _mediator.Send(
                        new GetIndicadorByMonthAndMaquinaQuery(
                                month,
                                year,
                                idMaquina,
                                IndicadorEnum.MTBF)));
            }
            catch (Exception e)
            {
                return SendExceptionRequest<int>(e);
            }
        }
    }
}
