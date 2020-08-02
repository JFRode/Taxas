using System;
using Taxas.Data.Context;
using Taxas.Domain.TaxaDeJuros.Builder;

namespace Taxas.Data.Seed
{
    public class TaxaDeJurosSeed : ITaxaDeJurosSeed
    {
        private readonly TaxasDbContext _taxasDbContext;

        public TaxaDeJurosSeed(TaxasDbContext taxasDbContext) =>
            _taxasDbContext = taxasDbContext;

        public void Executar()
        {
            var taxaDeJurosBuilder = new TaxaDeJurosBuilder();
            taxaDeJurosBuilder.WithId(Guid.NewGuid());
            taxaDeJurosBuilder.WithPercentual(0.01M);
            var taxaDeJuros = taxaDeJurosBuilder.Build();

            _taxasDbContext.Add(taxaDeJuros);
            _taxasDbContext.SaveChanges();
        }
    }
}