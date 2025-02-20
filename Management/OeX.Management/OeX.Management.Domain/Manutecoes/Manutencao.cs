using OeX.Management.Domain.Empresas;
using OeX.Management.Domain.MotivosManutencao;
using OeX.Management.Domain.Maquinas;
using OeX.Management.Domain.Commons;
namespace OeX.Management.Domain.Manutecoes
{
    public class Manutencao : Entity <int>
    {
        //----------------------------------------
        public DateTime DataHoraInicio { get; private set; }

        //----------------------------------------
        public DateTime? DataHoraFim { get; private set; }

        //----------------------------------------
        public long MotivoManutencaoId { get; private set; }
        public MotivoManutencao MotivoManutencao { get; private set; }

        //----------------------------------------
        public Guid EmpresaId { get; private set; }
        public Empresa Empresa { get; private set; }

        //----------------------------------------
        public int MaquinaId { get; private set; }
        public Maquina Maquina { get; private set; }
    }
}
