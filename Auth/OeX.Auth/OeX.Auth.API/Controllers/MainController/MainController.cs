using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OeX.Auth.API.Extensions;
using OeX.Auth.API.Interfaces;
using OeX.Auth.Application.Base;
using OeX.Auth.Application.Notificacoes;
using OeX.Auth.Application.Notificacoes.Interfaces;

namespace OeX.Auth.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;
        private readonly IUser AppUser;

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected MainController(INotificador notificador, IUser appUser)
        {
            _notificador = notificador;
            AppUser = appUser;

            if (AppUser.IsAuthenticated())
            {
                UsuarioId = AppUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse<T>(T result = default)
        {
            if (OperacaoValida())
                return Ok(Result<T>.Ok(result));

            return BadRequest(Result<T>
                              .Fail(_notificador
                                .ObterNotificacoes()
                                .Select(n => n.Mensagem)));
        }

        protected ActionResult CustomUnauthorizedResponse<T>()
        {
            return Unauthorized(Result<T>.Fail("User not logged in"));
        }

        protected ActionResult CustomFileResponse<T>(byte[] fileBytes, string contentType, string fileName)
        {
            if (OperacaoValida())
                return File(fileBytes, contentType, fileName);

            return BadRequest(Result<T>
                              .Fail(_notificador
                                .ObterNotificacoes()
                                .Select(n => n.Mensagem)));
        }

        protected ActionResult SendBadRequest<T>(string message)
        {
            return BadRequest(Result<T>
                              .Fail(message));
        }

        protected ActionResult SendInternalErrorRequest<T>(string message)
        {
            return StatusCode(500, (Result<T>
                              .Fail(message)));
        }

        protected ActionResult SendExceptionRequest<T>(Exception exception)
        {
            return BadRequest(Result<T>
                              .FailException(exception));
        }

        protected ActionResult CustomResponse<T>(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);

            return CustomResponse<T>();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values
                .SelectMany(obj => obj.Errors);

            foreach (var erro in erros)
            {
                var errorMessage = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;

                NotificarErro(errorMessage);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
