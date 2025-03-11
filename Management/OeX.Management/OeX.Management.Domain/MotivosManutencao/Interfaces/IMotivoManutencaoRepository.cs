using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Domain.MotivosManutencao.Interfaces
{
    public interface IMotivoManutencaoRepository
    {
        void Adicionar(MotivoManutencao entity);
        void Atualizar(MotivoManutencao entity);
        void Remover(MotivoManutencao entity);
    }
}
