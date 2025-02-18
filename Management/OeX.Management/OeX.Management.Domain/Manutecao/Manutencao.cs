using OeX.Management.Domain.Empresas;
using OeX.Management.Domain.MotivosManutencao;
using OeX.Management.Domain.Maquinas;
namespace OeX.Management.Domain.Manutecao
{
    public class Manutencao
    {
        //----------------------------------------
        public DateTime? DataHoraInicio { get; set; }

        //----------------------------------------
        public DateTime? DataHoraFim { get; set; }

        //----------------------------------------
        public int MotivoManutencaoId { get; set; }
        public virtual MotivoManutencao MotivoManutencao { get; set; }

        //----------------------------------------
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        //----------------------------------------
        public int MaquinaId { get; set; }
        public virtual Maquina Maquina { get; set; }
    }
}
