using AutoMapper;
using OeX.Management.Application.MotivosManutencao.DTOs;
using OeX.Management.Application.MotivosManutencao.Interfaces;
using OeX.Management.Domain.MotivosManutencao;
using OeX.Management.Domain.MotivosManutencao.Interfaces;
using OeX.Management.Domain.MotivosParada;
using OeX.Management.Domain.MotivosParada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Application.MotivosManutencao.Services
{
    public class MotivoManutencaoService : IMotivoManutencaoService
    {

        private readonly IMapper _mapper;
        private readonly IMotivoManutencaoRepository _repository;

        public MotivoManutencaoService(IMotivoManutencaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CriarMotivoManutencao(MotivoManutencaoDTO motivoManutencaoDTO)
        {
            var motivoManutencao = _mapper.Map<MotivoManutencao>(motivoManutencaoDTO);
            _repository.Adicionar(motivoManutencao);

        }

        public void EditarMotivoManutencao(MotivoManutencaoDTO motivoManutencaoDTO)
        {
            var motivoManutencao = _mapper.Map<MotivoManutencao>(motivoManutencaoDTO);
            _repository.Atualizar(motivoManutencao);

        }
        public void DeletarMotivoManutencao(MotivoManutencaoDTO motivoManutencaoDTO)
        {
            var motivoManutencao = _mapper.Map<MotivoManutencao>(motivoManutencaoDTO);
            _repository.Remover(motivoManutencao);

        }
    }
}

