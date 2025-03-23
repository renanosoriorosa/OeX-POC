using AutoMapper;
using OeX.Management.Application.MotivosParada.DTOs;
using OeX.Management.Application.MotivosParada.Interfaces;
using OeX.Management.Domain.MotivosParada;
using OeX.Management.Domain.MotivosParada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Application.MotivosParada.Services
{
    public class MotivoParadaService : IMotivoParadaService
    {
        private readonly IMapper _mapper;
        private readonly IMotivoParadaRepository _repository;

        public MotivoParadaService(IMotivoParadaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CriarMotivoParada(MotivoParadaDTO motivoParadaDTO)
        {
            var motivoParada = _mapper.Map<MotivoParada>(motivoParadaDTO);
            _repository.Adicionar(motivoParada);

        }

        public void EditarMotivoParada(MotivoParadaDTO motivoParadaDTO)
        {
            var motivoParada = _mapper.Map<MotivoParada>(motivoParadaDTO);
            _repository.Atualizar(motivoParada);

        }
        public void DeletarMotivoParada(MotivoParadaDTO motivoParadaDTO)
        {
            var motivoParada = _mapper.Map<MotivoParada>(motivoParadaDTO);
            _repository.Remover(motivoParada);

        }
    }
}
