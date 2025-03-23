using OeX.Management.Application.Maquinas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Application.Maquinas.Interfaces
{
    public interface IMaquinaService
    {
        void CriarMaquina(MaquinaDTO maquinaDTO);

        void EditarMaquina(MaquinaDTO maquinaDTO);

        void DeletarMaquina(MaquinaDTO maquinaDTO);
    }
}

