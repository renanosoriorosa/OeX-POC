using OeX.Dashboard.Domain.Commons;
using OeX.Dashboard.Domain.Empresas;
using OeX.Dashboard.Domain.Maquinas;

namespace OeX.Dashboard.Domain.OrdensProducao
{
    public class OrdemProducao : Entity<long>
    {
        public int Codigo { get; private set; }
        public int QuanrtidadePrevista { get; private set; }
        public int QuanrtidadeProduzida { get; private set; }
        public int QuanrtidadePerdida { get; private set; }
        public DateTime DataHoraInicio { get; private set; }
        public DateTime? DataHoraFim { get; private set; }
        public Guid EmpresaId { get; private set; }
        public Empresa Empresa { get; private set; }
        public int MaquinaId { get; private set; }
        public Maquina Maquina { get; private set; }
        public long ManagementId { get; private set; }
    }
}
