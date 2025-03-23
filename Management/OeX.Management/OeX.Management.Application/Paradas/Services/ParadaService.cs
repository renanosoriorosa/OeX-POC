using AutoMapper;
using OeX.Management.Application.Paradas.DTOs;
using OeX.Management.Application.Paradas.Interfaces;
using OeX.Management.Domain.Common.Interfaces;
using OeX.Management.Domain.Paradas;
using OeX.Management.Domain.Paradas.Interfaces;


namespace OeX.Management.Application.Paradas.Services
{
    public class ParadaService : IParadaService
    {
        private readonly IMapper _mapper;
        private readonly IParadaRepository _repository;

        public ParadaService(IMapper mapper , IParadaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public void CriarParada(ParadaDTO paradaDTO)
        {
            var parada = _mapper.Map<Parada>(paradaDTO);
            _repository.Adicionar(parada);
        }

        public void DeletarParada(ParadaDTO paradaDTO)
        {
            var parada = _mapper.Map<Parada>(paradaDTO);
            _repository.Remover(parada);
        }

        public void EditarParada(ParadaDTO paradaDTO)
        {
            var parada = _mapper.Map<Parada>(paradaDTO);
            _repository.Atualizar(parada);
        }
    }
}
