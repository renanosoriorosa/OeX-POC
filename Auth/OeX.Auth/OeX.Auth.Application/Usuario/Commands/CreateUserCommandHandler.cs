using MediatR;
using Microsoft.AspNetCore.Identity;
using OeX.Auth.Application.Base;
using OeX.Auth.Application.Notificacoes.Interfaces;
using OeX.Auth.Domain.Common;
using OeX.Auth.Domain.Tenants;
using OeX.Auth.Domain.Usuarios;
using OeX.Auth.Domain.Usuarios.Validations;

namespace OeX.Auth.Application.Usuarios.Commands
{
    public class CreateUserCommandHandler : BaseService, IRequestHandler<CreateUserCommand, bool>
    {
        private readonly ITenantService _tenantService;
        private readonly UserManager<Usuario> _userManager;

        public CreateUserCommandHandler(INotificador notificador, IUnitOfWork uow, ITenantService tenantService, UserManager<Usuario> userManager) : base(notificador, uow)
        {
            _tenantService = tenantService;
            _userManager = userManager;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
			{
                if (request.Password != request.ConfirmPassword)
                {
                    Notificar("As senhas não conferem.");
                    return false;
                }

                var empresaId = _tenantService.GetTenant();

                if (string.IsNullOrEmpty(empresaId))
                {
                    Notificar("Empresa não identificada.");
                    return false;
                }

                var usuario = new Usuario(request.Nome, new Guid(empresaId), request.Email);

                if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;

                var result = await _userManager.CreateAsync(usuario, request.Password);

                foreach (var error in result.Errors)
                    Notificar(error.Description);

                if (TemNotificacao())
                    return false;

                return true;
            }
			catch (Exception)
			{
				throw;
			}
        }
    }
}
