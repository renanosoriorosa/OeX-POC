using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Domain.Paradas.Interfaces
{
    public interface IParadaRepository
    {
        void Adicionar(Parada entity);
        void Atualizar(Parada entity);
        void Remover(Parada entity);
    }
}
