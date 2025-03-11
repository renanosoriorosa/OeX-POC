using FluentValidation;
using FluentValidation.Validators;
using OeX.Management.Domain.MotivosManutencao.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Domain.Maquinas.Validations
{
    public class MaquinaValidation : AbstractValidator<Maquina>
    {
        public MaquinaValidation()
        {

            RuleFor(j => j.CapacidadeProdutiva)
                .NotEmpty().WithMessage("Digite a capacidade produtiva do equipamento!")
                .GreaterThanOrEqualTo(1).WithMessage("Capacidade deve ser maior ou igual a 1!");
            RuleFor(j => j.Nome)
                .NotEmpty().WithMessage("Digite o nome do equipamento!");

        }
    }
}
