using Microsoft.AspNetCore.Identity;
using OeX.Auth.Domain.Empresas;

namespace OeX.Auth.Domain.Usuarios
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; private set; }
        public Empresa Empresa { get; set; }
        public Guid EmpresaId { get; set; }

        public Usuario()
        {
        }

        public Usuario(string nome, Guid empresaId, string email)
        {
            Nome = nome;
            EmpresaId = empresaId;
            UserName = email;
            Email = email;
            EmailConfirmed = true;
        }
    }
}
