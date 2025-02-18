using OeX.Management.Domain.Maquinas;
using OeX.Management.Domain.MotivosParada;
using OeX.Management.Domain.Empresas;

namespace OeX.Management.Domain.Paradas
{
    public class Parada
    {
        //----------------------------------------
        public DateTime? DataHoraInicio { get; set; }

        //----------------------------------------
        public DateTime? DataHoraFim { get; set; }

        //----------------------------------------
        public int MotivoManutencaoId { get; set; }
        public virtual MotivoParada MotivoParada { get; set; }

        //----------------------------------------
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        //----------------------------------------
        public int MaquinaId { get; set; }
        public virtual Maquina Maquina { get; set; }
    }
}
