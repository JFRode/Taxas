using SDK.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace Taxas.Application.Interfaces.Services
{
    public interface ITaxaDeJurosService
    {
        Task<TaxaDeJurosDto> GetAsync(CancellationToken cancellationToken);
    }
}