using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Domain.Paradas.Validations
{
    public class ParadaValidation : AbstractValidator<Parada>
    {
        public ParadaValidation() 
        {
            RuleFor(j => j.MotivoParada)
                .NotEmpty().WithMessage("Digite o do motivo da parada!");

            RuleFor(j => j.DataHoraFim)
                .NotEmpty().WithMessage("Digite a da hora fim da parada!")
                .GreaterThan(j => j.DataHoraInicio).WithMessage("Data hora fim deve ser maior que Data hora inicio!");
          
            RuleFor(j => j.DataHoraInicio)
                .NotEmpty().WithMessage("Digite a da hora início da parada!");
                
            RuleFor(j => j.MaquinaId)
                .GreaterThan(0);

            RuleFor(j => j.EmpresaId)
                 .NotEmpty();

            RuleFor(j => j.MotivoManutencaoId)
                 .GreaterThan(0);
            
        }

    }
}
