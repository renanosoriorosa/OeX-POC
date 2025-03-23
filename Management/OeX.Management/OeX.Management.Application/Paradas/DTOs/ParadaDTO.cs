using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Application.Paradas.DTOs
{
    public class ParadaDTO
    {
        public long Id { get; set; }
        public DateTime DataHoraInicio { get; set; }

        public DateTime? DataHoraFim { get; set; }

        public long MotivoParadaId { get; set; }

        public Guid EmpresaId { get; set; }

        public int MaquinaId { get; set; }
    }
}
