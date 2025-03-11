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

        public ManutencaoValidation()
        {
            RuleFor(j => j.MaquinaId)
                .NotEmpty().WithMessage("Necessário selecionar equipamento!")
                .GreaterThan(1).WithMessage("Selecione o equipamento");
            RuleFor(j => j.DataHoraInicio)
              .NotEmpty().WithMessage("Necessário definir Data Hora Início!");
            RuleFor(j => j.DataHoraFim)
               .NotEmpty().WithMessage("Necessário definir Data Hora Fim!")
               .GreaterThan(j => j.DataHoraInicio).WithMessage("Data Hora Fim deve ser maior que Data Hora Início!");
            RuleFor(j => j.MotivoManutencaoId)
               .NotEmpty().WithMessage("Necessário selecionar Motivo de Manutenção!")
               .GreaterThan(1).WithMessage("Selecione o Motivo!");


        }

    }
}
