using FluentValidation;

namespace OeX.Auth.Domain.Empresas.Validations
{
    public class EmpresaValidation : AbstractValidator<Empresa>
    {
        public EmpresaValidation()
        {
            RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("O campo nome precisa ser fornecido.")
                    .Length(3, 20).WithMessage("O campo código precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(c => c.CNPJ)
                .Length(14).WithMessage("O campo CNPJ precisa ter entre 14 caracteres.");

            RuleFor(c => c.TempoTrabalho)
                .GreaterThan(0)
                .WithMessage("O campo tempo de trabalho precisa ser maior que zero.");
        }
    }
}
