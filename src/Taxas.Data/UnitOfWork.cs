using System;
using System.Threading.Tasks;
using Taxas.Application.Interfaces;
using Taxas.Application.Interfaces.Repositories;
using Taxas.Data.Context;
using Taxas.Data.Repositories;

namespace Taxas.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaxasDbContext _taxasDbContext;
        private ITaxaDeJurosRepository _taxaDeJurosRepository;
        private bool _disposed;

        public UnitOfWork(TaxasDbContext taxasDbContext)
        {
            _taxasDbContext = taxasDbContext;
        }

        public ITaxaDeJurosRepository TaxaDeJurosRepository => _taxaDeJurosRepository ??= new TaxaDeJurosRepository(_taxasDbContext);

        public void SaveChanges()
        {
            _taxasDbContext.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _taxasDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _taxasDbContext?.Dispose();
                _taxaDeJurosRepository?.Dispose();
            }

            _disposed = true;
        }
    }
}