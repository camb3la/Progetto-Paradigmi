using FluentValidation;
using Paradigmi.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Application.Validators
{
    public class CreaTokenJWTValidator : AbstractValidator<CreaTokenJWTRequest>
    {
        public CreaTokenJWTValidator()
        {

            RuleFor(x => x.Email)
            .NotNull().WithMessage("Email non puo essere nulla")
            .NotEmpty().WithMessage("Email non puo essere vuota")
            .EmailAddress().WithMessage("Questa Email non è valida")
            .MinimumLength(5)
            .WithMessage("Email deve essere lunga almeno 5 caratteri")
            .MaximumLength(30)
            .WithMessage("Email deve essere lunga al massimo 30 caratteri");

            RuleFor(x => x.Password)
            .NotNull().WithMessage("Password non puo essere nulla")
            .NotEmpty().WithMessage("Password non puo essere vuota")
            .MinimumLength(5)
            .WithMessage("Password deve essere lunga almeno 5 caratteri")
            .MaximumLength(10)
            .WithMessage("Password deve essere lunga al massimo 10 caratteri");
           
        }
    }
}
