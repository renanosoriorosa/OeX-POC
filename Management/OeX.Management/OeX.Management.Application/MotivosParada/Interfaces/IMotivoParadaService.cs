using OeX.Management.Application.MotivosParada.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Application.MotivosParada.Interfaces
{
    public interface IMotivoParadaService
    {
        void CriarMotivoParada(MotivoParadaDTO motivoParadaDTO);

        void EditarMotivoParada(MotivoParadaDTO motivoParadaDTO);

        void DeletarMotivoParada(MotivoParadaDTO motivoParadaDTO);
    }
}
