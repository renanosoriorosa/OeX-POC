using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OeX.Management.Application.Manutencoes.DTOs;
using OeX.Management.Application.Manutencoes.Interfaces;
using OeX.Management.Application.MotivosParada.DTOs;
using OeX.Management.Application.MotivosParada.Interfaces;

namespace OeX.Management.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class MantencaoController : ControllerBase
    {
        private readonly IManutencaoService _manutencaoService;

        public MantencaoController(IManutencaoService manutencaoService)
        {
            _manutencaoService = manutencaoService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarMotivoParada(ManutencaoDTO manutencaoDTO)
        {
            _manutencaoService.CriarManutencao(manutencaoDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditarMotivoParada(ManutencaoDTO manutencaoDTO)
        {
            _manutencaoService.EditarManutencao(manutencaoDTO);
            return Ok();

        }
        [HttpDelete]
        public async Task<IActionResult> DeletarManutencao(ManutencaoDTO manutencaoDTO)
        {
            _manutencaoService.DeletarManutencao(manutencaoDTO);
            return Ok();

        }

    }
}
