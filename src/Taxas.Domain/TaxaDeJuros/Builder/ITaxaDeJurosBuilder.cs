using System;

namespace Taxas.Domain.TaxaDeJuros.Builder
{
    public interface ITaxaDeJurosBuilder
    {
        TaxaDeJurosBuilder WithId(Guid id);

        TaxaDeJurosBuilder WithPercentual(decimal percentual);

        TaxaDeJuros Build();
    }
}