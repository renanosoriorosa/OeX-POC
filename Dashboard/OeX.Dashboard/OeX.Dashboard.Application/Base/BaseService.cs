using FluentValidation;
using FluentValidation.Results;
using OeX.Auth.Domain.Common;
using OeX.Dashboard.Application.Notificacoes;
using OeX.Dashboard.Application.Notificacoes.Interfaces;

namespace OeX.Dashboard.Application.Base
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;
        private readonly IUnitOfWork _uow;

        protected BaseService(INotificador notificador, IUnitOfWork uow)
        {
            _notificador = notificador;
            _uow = uow;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : class
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }

        protected async Task<bool> Commit()
        {
            if (await _uow.Commit()) return true;

            return false;
        }
    }
}
