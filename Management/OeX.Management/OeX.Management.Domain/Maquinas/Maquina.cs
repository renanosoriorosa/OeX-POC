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
	public class Maquina : Entity<int>
	{
        //-----------------------------------
        [StringLength(25)]
        public string Nome { get; private set; }

		[StringLength(200)]
		public string? Descricao { get; private set; }

        //-----------------------------------
        public int CapacidadeProdutiva { get; private set; }

		//-----------------------------------
		public Guid EmpresaId { get; private set; }
		public Empresa Empresa { get; private set; }

	}
}
