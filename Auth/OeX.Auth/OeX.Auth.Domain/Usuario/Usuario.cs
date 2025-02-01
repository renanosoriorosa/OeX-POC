using Microsoft.AspNetCore.Identity;
using OeX.Auth.Domain.Empresas;

namespace OeX.Auth.Domain.Usuarios
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; private set; }
        public Empresa Empresa { get; set; }
        public Guid EmpresaId { get; set; }
    }
}
