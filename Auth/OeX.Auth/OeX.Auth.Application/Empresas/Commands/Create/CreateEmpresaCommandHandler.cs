using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OeX.Auth.Application.Base;
using OeX.Auth.Application.Notificacoes.Interfaces;
using OeX.Auth.Domain.Common;
using OeX.Auth.Domain.Empresas;
using OeX.Auth.Domain.Empresas.Interfaces;
using OeX.Auth.Domain.Empresas.Validations;
using OeX.Auth.Domain.Usuarios;
using OeX.Auth.Domain.Usuarios.Validations;

namespace OeX.Auth.Application.Empresas.Commands.Create
{
    public class CreateEmpresaCommandHandler : BaseService, IRequestHandler<CreateEmpresaCommand, bool>
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMediator _mediator;
        public CreateEmpresaCommandHandler(
            INotificador notificador,
            UserManager<Usuario> userManager,
            IUnitOfWork uow,
            IEmpresaRepository empresaRepository,
            IMediator mediator) : base(notificador, uow)
        {
            _userManager = userManager;
            _empresaRepository = empresaRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
        {
            var empresa = new Empresa(request.Nome, request.CNPJ, request.TempoTrabalho);
            var usuario = new Usuario(request.NomeUsuario, empresa, request.Email);

            if (request.Password != request.ConfirmPassword)
            {
                Notificar("As senhas não conferem.");
                return false;
            }

            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;
            if (!ExecutarValidacao(new EmpresaValidation(), empresa)) return false;

            try
            {
                _empresaRepository.Adicionar(empresa);

                if (!await Commit())
                {
                    Notificar("Falha ao salvar empresa no banco.");
                    return false;
                }

                var result = await _userManager.CreateAsync(usuario, request.Password);

                foreach (var error in result.Errors)
                    Notificar(error.Description);

                if (TemNotificacao())
                {
                    _empresaRepository.Remover(empresa);
                    await Commit();
                    return false;
                }

                var resultDashboard = await _mediator.Send(
                                        new CreateEmpresaDashboardCommand(
                                                        empresa.Id,
                                                        empresa.Nome,
                                                        empresa.CNPJ,
                                                        empresa.TempoTrabalho));

                Notificar(resultDashboard);

                if (TemNotificacao())
                {
                    _empresaRepository.Remover(empresa);
                    await _userManager.DeleteAsync(usuario);
                    await Commit();
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
