using Microsoft.EntityFrameworkCore;
using System;
using Taxas.Domain.TaxaDeJuros;
using Taxas.Domain.TaxaDeJuros.Builder;

namespace Taxas.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var taxaDeJurosBuilder = new TaxaDeJurosBuilder();
            modelBuilder.Entity<TaxaDeJuros>().HasData(
                taxaDeJurosBuilder
                    .WithId(Guid.NewGuid())
                    .WithPercentual(0.01M)
                    .Build()
            );
        }
    }
}