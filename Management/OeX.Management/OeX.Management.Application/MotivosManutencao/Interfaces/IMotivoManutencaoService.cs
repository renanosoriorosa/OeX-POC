using OeX.Management.Application.MotivosManutencao.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Application.MotivosManutencao.Interfaces
{
    public interface IMotivoManutencaoService
    {
        void CriarMotivoManutencao(MotivoManutencaoDTO motivoManutencaoDTO);

        void EditarMotivoManutencao(MotivoManutencaoDTO motivoManutencaoDTO);

        void DeletarMotivoManutencao(MotivoManutencaoDTO motivoManutencaoDTO);
    }
}
