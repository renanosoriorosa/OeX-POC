using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using OeX.Management.Application.MotivosManutencao.DTOs;
using OeX.Management.Application.MotivosManutencao.Interfaces;

namespace OeX.Management.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class MotivoManutencaoController : ControllerBase
    {
        private readonly IMotivoManutencaoService _motivoManutencaoService;

        public MotivoManutencaoController(IMotivoManutencaoService motivoManutencaoService)
        {
            _motivoManutencaoService = motivoManutencaoService;
        }

        [HttpGet]
        public async Task<IActionResult> CriarMotivoManutencao(MotivoManutencaoDTO motivoManutencaoDTO)
        {
            _motivoManutencaoService.CriarMotivoManutencao(motivoManutencaoDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditarMotivoManutencao(MotivoManutencaoDTO motivoManutencaoDTO)
        {
            _motivoManutencaoService.EditarMotivoManutencao(motivoManutencaoDTO);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarMotivoManutencao(MotivoManutencaoDTO motivoManutencaoDTO)
        {
            _motivoManutencaoService.DeletarMotivoManutencao(motivoManutencaoDTO);
            return Ok();
        }
    }
}
