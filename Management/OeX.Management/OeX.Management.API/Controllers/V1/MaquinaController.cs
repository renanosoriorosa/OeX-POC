using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OeX.Management.Application.Maquinas.DTOs;
using OeX.Management.Application.Maquinas.Interfaces;


namespace OeX.Management.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    //[Authorize]
    [ApiController]
    public class MaquinaController : ControllerBase
    {
        private readonly IMaquinaService _maquinaService;

        public MaquinaController(IMaquinaService maquinaService)
        {
            _maquinaService = maquinaService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarMaquina(MaquinaDTO maquinaDTO)
        {
            _maquinaService.CriarMaquina(maquinaDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditarMaquina(MaquinaDTO maquinaDTO)
        {
            _maquinaService.EditarMaquina(maquinaDTO);
            return Ok();

        }
        [HttpDelete]
        public async Task<IActionResult> DeletarMaquina(MaquinaDTO maquinaDTO)
        {
            _maquinaService.DeletarMaquina(maquinaDTO);
            return Ok();

        }

    }
}
