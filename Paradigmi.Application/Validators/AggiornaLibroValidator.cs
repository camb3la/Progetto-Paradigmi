using FluentValidation;
using Paradigmi.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Validators
{
    public class AggiornaLibroValidator : AbstractValidator<AggiornaLibroRequest>
    {
        public AggiornaLibroValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Id non puo essere nullo")
                .NotEmpty()
                .WithMessage("Id non puo essere vuoto")
                .GreaterThan(0)
                .WithMessage("IdLibro deve essere maggiore di 0");

            RuleFor(x => x.Nome)
            .NotNull().WithMessage("Nome non puo essere nullo")
            .NotEmpty().WithMessage("Nome non puo essere vuoto")
            .MinimumLength(5)
            .WithMessage("Nome deve essere lungo almeno 5 caratteri")
            .MaximumLength(30)
            .WithMessage("Nome deve essere lungo al massimo 30 caratteri");

            RuleFor(x => x.Autore)
            .NotNull().WithMessage("Autore non puo essere nullo")
            .NotEmpty().WithMessage("Autore non puo essere vuoto")
            .MinimumLength(5)
            .WithMessage("Autore deve essere lungo almeno 5 caratteri")
            .MaximumLength(20)
            .WithMessage("Autore deve essere lungo al massimo 20 caratteri");


            RuleFor(x => x.Editore)
            .NotNull().WithMessage("Editore non puo essere nullo")
            .NotEmpty().WithMessage("Editore non puo essere vuoto")
            .MinimumLength(5)
            .WithMessage("Editore deve essere lungo almeno 5 caratteri")
            .MaximumLength(20)
            .WithMessage("Editore deve essere lungo al massimo 20 caratteri");

            RuleFor(x => x.DataPubblicazione)
            .NotNull().WithMessage("DataPubblicazione non puo essere nulla");
        }
    }
}
