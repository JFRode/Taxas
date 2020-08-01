using Microsoft.EntityFrameworkCore;
using Taxas.Domain.TaxaDeJuros;

namespace Taxas.Data.Context
{
    public class TaxasDbContext : DbContext
    {
        public DbSet<TaxaDeJuros> TaxasDeJuros { get; set; }

        public TaxasDbContext(DbContextOptions<TaxasDbContext> options) : base(options)
        {
        }
    }
}