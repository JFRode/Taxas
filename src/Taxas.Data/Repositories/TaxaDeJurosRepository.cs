using SDK.Base;
using Taxas.Application.Interfaces.Repositories;
using Taxas.Data.Context;
using Taxas.Domain.TaxaDeJuros;

namespace Taxas.Data.Repositories
{
    public class TaxaDeJurosRepository : BaseRepository<TaxaDeJuros>, ITaxaDeJurosRepository
    {
        public TaxaDeJurosRepository(TaxasDbContext taxasDbContext) : base(taxasDbContext)
        {
        }
    }
}