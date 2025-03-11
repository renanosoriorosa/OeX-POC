using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Domain.Manutecoes.Interfaces
{
    public interface IManutencaoRepository
    {
        void Adicionar(Manutencao entity);
        void Atualizar(Manutencao entity);
        void Remover(Manutencao entity);
    }
}
