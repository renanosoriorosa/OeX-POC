using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Domain.Empresas.Interfaces
{
    public interface IEmpresaRepository
    {
        void Adicionar(Empresa entity);
        void Atualizar(Empresa entity);
        void Remover(Empresa entity);
    }
}
