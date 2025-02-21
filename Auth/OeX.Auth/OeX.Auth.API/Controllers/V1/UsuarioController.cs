using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OeX.Auth.API.Interfaces;
using OeX.Auth.Application.Notificacoes.Interfaces;
using OeX.Auth.Application.Usuarios.Commands;
using OeX.Auth.Application.Usuarios.Dtos;
using OeX.Auth.Application.Usuarios.Queries;

namespace OeX.Auth.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class UsuarioController : MainController
    {
        private readonly IMediator _mediator;

        public UsuarioController(INotificador notificador, IUser appUser, IMediator mediator) : base(notificador, appUser)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "ListagemUsuarios")]
        public async Task<IActionResult> ListagemUsuarios([FromQuery] GetUsersQuery query)
        {
            try
            {
                return CustomResponse(await _mediator.Send(query));
            }
            catch (Exception e)
            {
                return SendExceptionRequest<bool>(e);
            }
        }

        [HttpPost(Name = "Create")]
        public async Task<ActionResult> Create(RegisterUserDto registerUser)
        {
            try
            {
                return CustomResponse(await _mediator.Send(new CreateUserCommand(
                                                            registerUser.Nome,
                                                            registerUser.Email,
                                                            registerUser.Password,
                                                            registerUser.ConfirmPassword)));
            }
            catch (Exception e)
            {
                return SendExceptionRequest<bool>(e);
            }
        }
    }
}
