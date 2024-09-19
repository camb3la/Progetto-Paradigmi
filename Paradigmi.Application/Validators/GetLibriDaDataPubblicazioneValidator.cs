using FluentValidation;
using Paradigmi.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Validators
{
    public class GetLibriDaDataPubblicazioneValidator : AbstractValidator<GetLibriDaDataPubblicazioneRequest>
    {
        public GetLibriDaDataPubblicazioneValidator()
        {
            RuleFor(x => x.DataPubblicazione)
            .NotNull().WithMessage("DataPubblicazione non puo essere nulla");

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
