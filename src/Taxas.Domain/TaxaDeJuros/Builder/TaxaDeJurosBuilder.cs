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

        public TaxaDeJurosBuilder WithId(Guid id)
        {
            _taxaDeJuros.Id = id;
            return this;
        }

        public TaxaDeJurosBuilder WithPercentual(decimal percentual)
        {
            _taxaDeJuros.Percentual = percentual;
            return this;
        }
    }
}