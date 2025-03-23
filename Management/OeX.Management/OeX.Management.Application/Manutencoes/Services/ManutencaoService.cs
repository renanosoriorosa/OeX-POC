using AutoMapper;
using OeX.Management.Application.Manutencoes.DTOs;
using OeX.Management.Application.Manutencoes.Interfaces;
using OeX.Management.Domain.Manutecoes;
using OeX.Management.Domain.Manutecoes.Interfaces;
using OeX.Management.Domain.MotivosManutencao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Application.Manutencoes.Services
{
    public class ManutencaoService : IManutencaoService
    {
        private readonly IMapper _mapper;
        private readonly IManutencaoRepository _repository;

        public ManutencaoService(IManutencaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void CriarManutencao(ManutencaoDTO manutencaoDTO)
        {
            var manutencao = _mapper.Map<Manutencao>(manutencaoDTO);
            _repository.Adicionar(manutencao);

        }

        public void DeletarManutencao(ManutencaoDTO manutencaoDTO)
        {
            var manutencao = _mapper.Map<Manutencao>(manutencaoDTO);
            _repository.Remover(manutencao);
        }

        public void EditarManutencao(ManutencaoDTO manutencaoDTO)
        {
            var manutencao = _mapper.Map<Manutencao>(manutencaoDTO);
            _repository.Atualizar(manutencao);
        }
    }
}
