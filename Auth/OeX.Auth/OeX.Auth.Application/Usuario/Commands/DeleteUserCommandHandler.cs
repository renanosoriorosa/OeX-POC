using MediatR;
using OeX.Auth.Application.Base;
using OeX.Auth.Application.Notificacoes.Interfaces;
using OeX.Auth.Domain.Common;
using OeX.Auth.Domain.Usuarios.Interfaces;

namespace OeX.Auth.Application.Usuarios.Commands
{
    public class DeleteUserCommandHandler : BaseService, IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public DeleteUserCommandHandler(INotificador notificador, IUnitOfWork uow, IUsuarioRepository usuarioRepository) : base(notificador, uow)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Id))
            {
                Notificar($"Informe o id do usuário.");
                return false;
            }

            var user = await _usuarioRepository.ObterPorId(request.Id);

            if (user == null)
            {
                Notificar($"O usuário {request.Id} não foi encontrado.");
                return false;
            }

            try
            {
                _usuarioRepository.Remover(user);
                await Commit();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
