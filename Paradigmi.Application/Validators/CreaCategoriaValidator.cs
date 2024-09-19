using Paradigmi.Application.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Paradigmi.Application.Validators
{
    public class CreaCategoriaValidator : AbstractValidator<CreaCategoriaRequest>
    {
        public CreaCategoriaValidator()
        {
            RuleFor(x => x.Nome)
            .NotNull().WithMessage("Nome non puo essere nullo")
            .NotEmpty().WithMessage("Nome non puo essere vuoto")
            .MinimumLength(4)
            .WithMessage("Nome deve essere lungo almeno 4 caratteri")
            .MaximumLength(20)
            .WithMessage("Nome deve essere lungo al massimo 20 caratteri");
        }
    }
}
