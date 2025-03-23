using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Application.Maquinas.DTOs
{
    public class MaquinaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public int CapacidadeProdutiva { get; set; }
        public Guid EmpresaId { get; set; }
    }
}
