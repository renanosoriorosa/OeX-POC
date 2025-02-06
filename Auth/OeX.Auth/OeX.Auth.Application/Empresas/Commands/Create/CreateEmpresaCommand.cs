using MediatR;
using OeX.Auth.Domain.Usuarios;

namespace OeX.Auth.Application.Empresas.Commands.Create
{
    public class CreateEmpresaCommand : IRequest<bool> 
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public int TempoTrabalho { get; set; }
        public string NomeUsuario  { get; set; }
        public string Email  { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
