using System;
using System.Threading.Tasks;
using Taxas.Application.Interfaces.Repositories;

namespace Taxas.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITaxaDeJurosRepository TaxaDeJurosRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}