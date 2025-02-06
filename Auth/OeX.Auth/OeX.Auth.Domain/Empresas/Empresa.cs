using OeX.Auth.Domain.Commons;
using OeX.Auth.Domain.Usuarios;

namespace OeX.Auth.Domain.Empresas
{
    public class Empresa : Entity<Guid>
    {
        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public int TempoTrabalho { get; private set; }
        public ICollection<Usuario> Usuarios { get; set; }

        public Empresa() { }

        public Empresa(string nome, string cNPJ, int tempoTrabalho)
        {
            Nome = nome;
            CNPJ = cNPJ;
            TempoTrabalho = tempoTrabalho;
        }
    }
}
