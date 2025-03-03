using OeX.Dashboard.Domain.Commons;
using OeX.Dashboard.Domain.Empresas;
using System.ComponentModel.DataAnnotations;

namespace OeX.Dashboard.Domain.Maquinas
{
    public class Maquina : Entity<int>
    {
        [StringLength(25)]
        public string Nome { get; private set; }
        [StringLength(200)]
        public string? Descricao { get; private set; }
        public int CapacidadeProdutiva { get; private set; }
        public Guid EmpresaId { get; private set; }
        public Empresa Empresa { get; private set; }
        public long ManagementId { get; private set; }

    }
}
