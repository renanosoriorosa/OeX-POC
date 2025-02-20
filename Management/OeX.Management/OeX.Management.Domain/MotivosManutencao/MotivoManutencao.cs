using System.ComponentModel.DataAnnotations;
using OeX.Management.Domain.Commons;
using OeX.Management.Domain.Empresas;
namespace OeX.Management.Domain.MotivosManutencao
{
    public class MotivoManutencao : Entity<long>
    {
        //-----------------------------------
        [StringLength(25)]
        public string Codigo { get; private set; }

        //-----------------------------------
        [StringLength(200)]
        public string? Descricao { get; private set; }

        //-----------------------------------
        public Guid EmpresaId { get; private set; }
        public Empresa Empresa { get; private set; }
    }
}
