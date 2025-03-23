using AutoMapper;
using OeX.Management.Application.Maquinas.DTOs;
using OeX.Management.Application.Maquinas.Interfaces;
using OeX.Management.Domain.Manutecoes.Interfaces;
using OeX.Management.Domain.Maquinas;
using OeX.Management.Domain.Maquinas.Interfaces;


namespace OeX.Management.Application.Maquinas.Services
{
    public class MaquinaService : IMaquinaService
    {
        private readonly IMapper _mapper;
        private readonly IMaquinaRepository _repository;
        public MaquinaService(IMaquinaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void CriarMaquina(MaquinaDTO maquinaDTO)
        {
            var maquina = _mapper.Map<Maquina>(maquinaDTO);
            _repository.Adicionar(maquina);
        }

        public void DeletarMaquina(MaquinaDTO maquinaDTO)
        {
            var maquina = _mapper.Map<Maquina>(maquinaDTO);
            _repository.Remover(maquina);
        }

        public void EditarMaquina(MaquinaDTO maquinaDTO)
        {
            var maquina = _mapper.Map<Maquina>(maquinaDTO);
            _repository.Atualizar(maquina);
        }
    }
}
