using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Application.Manutencoes.DTOs
{
    public class ManutencaoDTO
    {
        public int Id { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public long MotivoManutencaoId { get; set; }
        public Guid EmpresaId { get; set; }
        public int MaquinaId { get; set; }
    }
}
