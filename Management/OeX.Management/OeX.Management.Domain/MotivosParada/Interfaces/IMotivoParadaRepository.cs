using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Domain.MotivosParada.Interfaces
{
    public interface IMotivoParadaRepository
    {
        void Adicionar(MotivoParada entity);
        void Atualizar(MotivoParada entity);
        void Remover(MotivoParada entity);
    }
}
