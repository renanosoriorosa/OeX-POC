using OeX.Management.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OeX.Management.Domain.Empresas;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OeX.Management.Domain.Maquinas
{
	public class Maquina
	{
        //-----------------------------------
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} a {1} caracteres")]
        public string Nome { get; set; }

		[StringLength(200, ErrorMessage = "O numero máximo de caracteres é {1}")]
		[AllowNull]
		public string Descricao { get; set; }

        //-----------------------------------
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public double CapacidadeProdutiva { get; set; }

		//-----------------------------------
		public int EmpresaId { get; set; }
		public virtual Empresa Empresa { get; set; }

	}
}
