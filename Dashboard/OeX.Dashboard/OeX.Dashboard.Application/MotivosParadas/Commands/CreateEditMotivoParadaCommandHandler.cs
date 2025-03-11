using MediatR;
using OeX.Dashboard.Domain.Common;
using OeX.Dashboard.Application.Base;
using OeX.Dashboard.Application.Notificacoes.Interfaces;
using OeX.Dashboard.Domain.Empresas.Interfaces;
using OeX.Dashboard.Domain.MotivosParada;
using OeX.Dashboard.Domain.MotivosParada.Interfaces;

namespace OeX.Dashboard.Application.MotivosParadas.Commands
{
    public class CreateEditMotivoParadaCommandHandler : BaseService, IRequestHandler<CreateEditMotivoParadaCommand, Result<bool>>
    {
        private readonly IMotivoParadaRepository _motivoParadaRepository;
        private readonly IEmpresaRepository _empresaRepository;

        public CreateEditMotivoParadaCommandHandler(INotificador notificador, IUnitOfWork uow, IMotivoParadaRepository motivoParadaRepository, IEmpresaRepository empresaRepository) : base(notificador, uow)
        {
            _motivoParadaRepository = motivoParadaRepository;
            _empresaRepository = empresaRepository;
        }

        public async Task<Result<bool>> Handle(CreateEditMotivoParadaCommand request, CancellationToken cancellationToken)
        {
			try
			{
                var empresa = await _empresaRepository.ObterPorId(request.EmpresaId);

                if (empresa is null)
                    return Result<bool>.Fail($"Empresa {request.EmpresaId} não encontrada.");

                var motivoParada = await _motivoParadaRepository
                                                .BuscarPorIdManagementEEmpresa(
                                                        request.Id, 
                                                        empresa.Id);

                if (motivoParada is null)
                {
                    motivoParada = new MotivoParada(
                                                request.Codigo,
                                                request.Descricao,
                                                request.EmpresaId,
                                                request.Id);

                    _motivoParadaRepository.Adicionar(motivoParada);
                }
                else
                {
                    motivoParada.SetCodigo(request.Codigo)
                                .SetDescricao(request.Descricao);

                    _motivoParadaRepository.Atualizar(motivoParada);
                }

                if (!await Commit())
                    return Result<bool>.Fail("Falha ao salvar no banco de dados");

                return Result<bool>.Ok();
            }
			catch (Exception e)
			{
                return Result<bool>.FailException(e);
			}
        }
    }
}
