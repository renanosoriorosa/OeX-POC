using System.ComponentModel.DataAnnotations;

namespace OeX.Auth.Application.Usuarios.Dtos
{
    public class RegisterUserDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
