using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OeX.Dashboard.API.Interfaces;
using OeX.Dashboard.Application.IndicadoresMensais.Queries;
using OeX.Dashboard.Application.Notificacoes.Interfaces;
using OeX.Dashboard.Domain.Indicadores.Enums;

namespace OeX.Dashboard.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class OEEController : MainController
    {
        private readonly IMediator _mediator;

        public OEEController(INotificador notificador, IUser appUser, IMediator mediator) : base(notificador, appUser)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOEEByMonth(int month, int year, int idMaquina)
        {
            try
            {
                return CustomResponse(await _mediator.Send(
                        new GetIndicadorByMonthAndMaquinaQuery(
                                month,
                                year,
                                idMaquina,
                                IndicadorEnum.OEE)));
            }
            catch (Exception e)
            {
                return SendExceptionRequest<int>(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDisponibilidadeByMonth(int month, int year, int idMaquina)
        {
            try
            {
                return CustomResponse(await _mediator.Send(
                        new GetIndicadorByMonthAndMaquinaQuery(
                                month,
                                year,
                                idMaquina,
                                IndicadorEnum.Disponibilidade)));
            }
            catch (Exception e)
            {
                return SendExceptionRequest<int>(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetQualidadeByMonth(int month, int year, int idMaquina)
        {
            try
            {
                return CustomResponse(await _mediator.Send(
                        new GetIndicadorByMonthAndMaquinaQuery(
                                month,
                                year,
                                idMaquina,
                                IndicadorEnum.Qualidade)));
            }
            catch (Exception e)
            {
                return SendExceptionRequest<int>(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPerformanceByMonth(int month, int year, int idMaquina)
        {
            try
            {
                return CustomResponse(await _mediator.Send(
                        new GetIndicadorByMonthAndMaquinaQuery(
                                month,
                                year,
                                idMaquina,
                                IndicadorEnum.Performance)));
            }
            catch (Exception e)
            {
                return SendExceptionRequest<int>(e);
            }
        }
    }
}
