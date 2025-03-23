using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OeX.Management.Application.Paradas.DTOs;
using OeX.Management.Application.Paradas.Interfaces;

namespace OeX.Management.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class ParadaController : ControllerBase
    {
        private readonly IParadaService _paradaService;

        public ParadaController(IParadaService paradaService)
        {
            _paradaService = paradaService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarParada(ParadaDTO paradaDTO)
        {
            _paradaService.CriarParada(paradaDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditarParada(ParadaDTO paradaDTO)
        {
            _paradaService.EditarParada(paradaDTO);
            return Ok();

        }
        [HttpDelete]
        public async Task<IActionResult> DeletarParada(ParadaDTO paradaDTO)
        {
            _paradaService.DeletarParada(paradaDTO);
            return Ok();

        }

    }
}
