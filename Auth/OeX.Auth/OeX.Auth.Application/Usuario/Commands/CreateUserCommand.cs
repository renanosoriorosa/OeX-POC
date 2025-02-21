using MediatR;

namespace OeX.Auth.Application.Usuarios.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public CreateUserCommand(string nome, string email, string password, string confirmPassword)
        {
            Nome = nome;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
