using OeX.Management.Domain.Maquinas;
using OeX.Management.Domain.MotivosParada;
using OeX.Management.Domain.Empresas;
using OeX.Management.Domain.Commons;

namespace OeX.Management.Domain.Paradas
{
    public class Parada : Entity<long>
    {
        //----------------------------------------
        public DateTime DataHoraInicio { get; private set; }

        //----------------------------------------
        public DateTime? DataHoraFim { get; private set; }

        //----------------------------------------
        public long MotivoParadaId { get; private set; }
        public MotivoParada MotivoParada { get; private set; }

        //----------------------------------------
        public Guid EmpresaId { get; private set; }
        public  Empresa Empresa { get; private set; }

        //----------------------------------------
        public int MaquinaId { get; private set; }
        public  Maquina Maquina { get; private set; }
    }
}
