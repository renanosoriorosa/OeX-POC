using MediatR;
using OeX.Auth.Domain.Common;
using OeX.Dashboard.Application.Base;
using OeX.Dashboard.Application.Notificacoes.Interfaces;
using OeX.Dashboard.Domain.Empresas;
using OeX.Dashboard.Domain.Empresas.Interfaces;

namespace OeX.Dashboard.Application.Empresas.Commands
{
    public class CreateEmpresaCommandHandler : BaseService, IRequestHandler<CreateEmpresaCommand, bool>
    {

        private readonly IEmpresaRepository _empresaRepository;

        public CreateEmpresaCommandHandler(INotificador notificador, IUnitOfWork uow, IEmpresaRepository empresaRepository) : base(notificador, uow)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<bool> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
        {
			try
			{
                _empresaRepository.Adicionar(new Empresa(
                                                    request.Id,
                                                    request.Nome,
                                                    request.CNPJ,
                                                    request.TempoTrabalho));

                if(await Commit()) return true;

                Notificar("Ocorreu um erro ao salvar a empresa na API Dashboard");
                return false;
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
