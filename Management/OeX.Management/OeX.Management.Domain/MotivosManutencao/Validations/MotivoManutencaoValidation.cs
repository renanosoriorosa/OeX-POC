using FluentValidation;


namespace OeX.Management.Domain.MotivosManutencao.Validations
{
    public class MotivoManutencaoValidation : AbstractValidator<MotivoManutencao>
    {
      
        public MotivoManutencaoValidation()
        {
            RuleFor(j => j.Codigo)
                .NotEmpty().WithMessage("Digite o código do motivo da parada!");

        }
      
    }
}
