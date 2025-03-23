using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Application.MotivosManutencao.DTOs
{
    public class MotivoManutencaoDTO
    {
        public long Id { get; set; }
        public string Codigo { get; set; }

        public string? Descricao { get; set; }

        public Guid EmpresaId { get; set; }
    }
}
