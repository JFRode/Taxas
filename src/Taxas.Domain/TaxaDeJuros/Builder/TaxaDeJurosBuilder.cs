using System;

namespace Taxas.Domain.TaxaDeJuros.Builder
{
    public class TaxaDeJurosBuilder : ITaxaDeJurosBuilder
    {
        private readonly TaxaDeJuros _taxaDeJuros;

        public TaxaDeJurosBuilder() =>
            _taxaDeJuros = new TaxaDeJuros();

        public TaxaDeJuros Build() =>
            _taxaDeJuros;

        public void WithId(Guid id) =>
            _taxaDeJuros.Id = id;

        public void WithPercentual(decimal percentual) =>
            _taxaDeJuros.Percentual = percentual;
    }
}