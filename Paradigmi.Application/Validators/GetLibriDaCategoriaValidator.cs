using FluentValidation;
using Paradigmi.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Validators
{
    public class GetLibriDaCategoriaValidator : AbstractValidator<GetLibriDaCategoriaRequest>
    {
        public GetLibriDaCategoriaValidator()
        {
            RuleFor(x => x.Categoria)
            .NotNull().WithMessage("Categoria non puo essere nulla")
            .NotEmpty().WithMessage("Categoria non puo essere vuota")
            .MinimumLength(4)
            .WithMessage("Categoria deve essere lunga almeno 4 caratteri")
            .MaximumLength(20)
            .WithMessage("Categoria deve essere lunga al massimo 20 caratteri");

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
