using System;

namespace Taxas.Domain.TaxaDeJuros.Builder
{
    public interface ITaxaDeJurosBuilder
    {
        void WithId(Guid id);

        void WithPercentual(decimal percentual);

        TaxaDeJuros Build();
    }
}