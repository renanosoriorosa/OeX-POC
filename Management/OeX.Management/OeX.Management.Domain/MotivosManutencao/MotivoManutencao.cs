using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OeX.Management.Domain.Empresas;
namespace OeX.Management.Domain.MotivosManutencao
{
    public class MotivoManutencao
    {
        //-----------------------------------
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} a {1} caracteres")]
        public string Codigo { get; set; }

        //-----------------------------------
        [StringLength(200, ErrorMessage = "O numero máximo de caracteres é {1}")]
        [AllowNull]
        public string Descricao { get; set; }

        //-----------------------------------
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
