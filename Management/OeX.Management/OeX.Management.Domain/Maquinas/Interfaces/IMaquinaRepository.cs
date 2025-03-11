using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Domain.Maquinas.Interfaces
{
    public interface IMaquinaRepository
    {
        void Adicionar(Maquina entity);
        void Atualizar(Maquina entity);
        void Remover(Maquina entity);
    }
}
