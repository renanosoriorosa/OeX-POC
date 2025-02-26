using FluentValidation;
using OeX.Management.Domain.MotivosManutencao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OeX.Management.Domain.Manutecoes.Validations
{
    public class ManutencaoValidation : AbstractValidator<Manutencao>
    {

            //public ManutencaoValidation()
            //{
            //    RuleFor(j => j.Codigo)
            //        .NotEmpty().WithMessage("Digite o código do motivo da parada!");

            //}

    }
}
