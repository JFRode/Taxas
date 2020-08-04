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
            _taxasDbContext.Add(taxaDeJurosBuilder
                .WithId(Guid.NewGuid())
                .WithPercentual(0.01M)
                .Build());
            _taxasDbContext.SaveChanges();
        }
    }
}