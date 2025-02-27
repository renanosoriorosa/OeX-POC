using FluentValidation;
using FluentValidation.Validators;

namespace OeX.Management.Domain.MotivosParada.Validations
{
    public class MotivoParadaValidation : AbstractValidator<MotivoParada>
    {

        public MotivoParadaValidation()
        {
            RuleFor(j => j.Codigo)
                .NotEmpty().WithMessage("Digite o código do motivo da parada!");
            
        }
    }
}
