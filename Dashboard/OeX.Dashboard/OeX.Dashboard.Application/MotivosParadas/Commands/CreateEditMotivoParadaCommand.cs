using MediatR;
using OeX.Dashboard.Application.Base;

namespace OeX.Dashboard.Application.MotivosParadas.Commands
{
    public class CreateEditMotivoParadaCommand : IRequest<Result<bool>>
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string? Descricao { get; set; }
        public Guid EmpresaId { get; set; }
    }
}
