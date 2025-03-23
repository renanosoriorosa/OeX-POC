using OeX.Management.Application.Manutencoes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Application.Manutencoes.Interfaces
{
    public interface IManutencaoService
    {
        void CriarManutencao(ManutencaoDTO manutencaoDTO);

        void EditarManutencao(ManutencaoDTO manutencaoDTO);

        void DeletarManutencao(ManutencaoDTO manutencaoDTO);
    }
}
