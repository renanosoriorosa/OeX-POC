using FluentValidation;

namespace OeX.Auth.Domain.Usuarios.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("O campo nome precisa ser fornecido.")
                    .Length(3, 30).WithMessage("O campo nome precisa ter entre {MinLength} e {MaxLength} caracteres.");
            
            RuleFor(c => c.Email)
                    .NotEmpty().WithMessage("O campo email precisa ser fornecido.")
                    .EmailAddress().WithMessage("O e-mail deve estar em um formato válido.");
        }
    }
}
