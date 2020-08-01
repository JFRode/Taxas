using AutoMapper;
using SDK.Dtos;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Taxas.Application.Interfaces;
using Taxas.Application.Interfaces.Services;

namespace Taxas.Application.Services
{
    public class TaxaDeJurosService : ITaxaDeJurosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaxaDeJurosService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TaxaDeJurosDto> GetAsync(CancellationToken cancellationToken)
        {
            var taxaDeJuros = await Task.Run(() => _unitOfWork.TaxaDeJurosRepository.SelectAll().FirstOrDefault(), cancellationToken);
            return _mapper.Map<TaxaDeJurosDto>(taxaDeJuros);
        }
    }
}