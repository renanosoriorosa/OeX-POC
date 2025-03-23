using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OeX.Management.Application.MotivosParada.DTOs;
using OeX.Management.Application.MotivosParada.Interfaces;

namespace OeX.Management.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class MotivoParadaController : ControllerBase
    {
        private readonly IMotivoParadaService _motivoParadaService;

        public MotivoParadaController(IMotivoParadaService motivoParadaService)
        {
            _motivoParadaService = motivoParadaService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarMotivo(MotivoParadaDTO paradaDTO)
        {
            _motivoParadaService.CriarMotivoParada(paradaDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditarMotivoParada(MotivoParadaDTO paradaDTO)
        {
            _motivoParadaService.EditarMotivoParada(paradaDTO);
            return Ok();

        }
        [HttpDelete]
        public async Task<IActionResult> DeletarMotivoParada(MotivoParadaDTO paradaDTO)
        {
            _motivoParadaService.DeletarMotivoParada(paradaDTO);
            return Ok();

        }

    }
}
