using OeX.Dashboard.Domain.Commons;
using OeX.Dashboard.Domain.Empresas;
using OeX.Dashboard.Domain.Maquinas;
using OeX.Dashboard.Domain.MotivosParada;

namespace OeX.Dashboard.Domain.Paradas
{
    public class Parada : Entity<long>
    {
        public DateTime DataHoraInicio { get; private set; }
        public DateTime? DataHoraFim { get; private set; }
        public int MotivoParadaId { get; private set; }
        public MotivoParada MotivoParada { get; private set; }
        public Guid EmpresaId { get; private set; }
        public Empresa Empresa { get; private set; }
        public int MaquinaId { get; private set; }
        public Maquina Maquina { get; private set; }
        public long ManagementId { get; private set; }
    }
}
