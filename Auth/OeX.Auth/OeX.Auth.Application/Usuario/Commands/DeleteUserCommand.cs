using MediatR;

namespace OeX.Auth.Application.Usuarios.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public DeleteUserCommand(string id)
        {
            Id = id;
        }
    }
}
