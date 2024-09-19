using FluentValidation;
using Paradigmi.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Validators
{
    public class GetLibriDaAutoreValidator : AbstractValidator<GetLibriDaAutoreRequest>
    {
        public GetLibriDaAutoreValidator()
        {
            RuleFor(x => x.Autore)
            .NotNull().WithMessage("Autore non puo essere nullo")
            .NotEmpty().WithMessage("Autore non puo essere vuoto")
            .MinimumLength(5)
            .WithMessage("Autore deve essere lungo almeno 5 caratteri")
            .MaximumLength(20)
            .WithMessage("Autore deve essere lungo al massimo 20 caratteri");

            RuleFor(x => x.DimensionePagina)
                .GreaterThan(0)
                .WithMessage("DimensionePagina deve essere maggiore di 0")
                .LessThanOrEqualTo(10)
                .WithMessage("DimensionePagina deve essere minore o uguale a 10");

            RuleFor(x => x.NumeroPagina)
                .GreaterThanOrEqualTo(0)
                .WithMessage("NumeroPagina deve essere maggiore o uguale a 0");
        }
    }
}
