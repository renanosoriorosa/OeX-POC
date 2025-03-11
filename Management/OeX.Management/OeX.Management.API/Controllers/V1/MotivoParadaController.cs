using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OeX.Management.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class MotivoParadaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Teste()
        {
            return Ok();
        }

    }
}
