using OeX.Dashboard.Domain.Commons;
using OeX.Dashboard.Domain.Empresas;
using OeX.Dashboard.Domain.Maquinas;
using OeX.Dashboard.Domain.Maquinas.Enums;

namespace OeX.Dashboard.Domain.Indicadores
{
    public class IndicadorMensal : Entity<int>
    {
        public int Mes { get; private set; }
        public int Ano { get; private set; }
        public IndicadorEnum Indicador { get; private set; }
        public long Valor { get; private set; }
        public Guid EmpresaId { get; private set; }
        public Empresa Empresa { get; private set; }
        public int MaquinaId { get; private set; }
        public Maquina Maquina { get; private set; }
    }
}
