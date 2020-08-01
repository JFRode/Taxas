using FluentValidation;
using SDK.Dtos;
using System;
using Taxas.Application.Interfaces.Validators;

namespace Taxas.Application.Validators
{
    public class TaxaDeJurosValidator : AbstractValidator<TaxaDeJurosDto>, ITaxaDeJurosValidator
    {
        public TaxaDeJurosValidator()
        {
            RuleFor(x => x)
                .NotNull().WithMessage("O objeto TaxaDeJuros está nulo.");

            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O campo Id do objeto TaxaDeJuros está vazio.");
        }
    }
}