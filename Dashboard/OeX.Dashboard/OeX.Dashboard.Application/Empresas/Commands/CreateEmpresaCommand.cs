using MediatR;

namespace OeX.Dashboard.Application.Empresas.Commands
{
    public class CreateEmpresaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public int TempoTrabalho { get; set; }
    }
}
