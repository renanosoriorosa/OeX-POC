using FluentValidation;

namespace OeX.Auth.Domain.Usuarios.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("O campo nome precisa ser fornecido.")
                    .Length(3, 30).WithMessage("O campo código precisa ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
