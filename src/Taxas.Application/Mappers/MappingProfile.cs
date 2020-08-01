using AutoMapper;
using SDK.Dtos;
using Taxas.Domain.TaxaDeJuros;

namespace Taxas.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaxaDeJuros, TaxaDeJurosDto>().ReverseMap();
        }
    }
}