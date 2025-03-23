using OeX.Management.Application.Paradas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Application.Paradas.Interfaces
{
    public interface IParadaService
    {
        void CriarParada(ParadaDTO paradaDTO);

        void EditarParada(ParadaDTO paradaDTO);

        void DeletarParada(ParadaDTO paradaDTO);
    }
}
