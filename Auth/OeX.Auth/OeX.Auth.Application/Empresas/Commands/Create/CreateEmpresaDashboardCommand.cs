using MediatR;
using OeX.Auth.Application.Base;

namespace OeX.Auth.Application.Empresas.Commands.Create
{
    public class CreateEmpresaDashboardCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public int TempoTrabalho { get; set; }
    }
}
