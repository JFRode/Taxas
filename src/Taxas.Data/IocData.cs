using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Taxas.Application.Interfaces;
using Taxas.Application.Interfaces.Repositories;
using Taxas.Data.Context;
using Taxas.Data.Repositories;
using Taxas.Data.Seed;

namespace Taxas.Data
{
    public static class IocData
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services) =>
            services.AddScoped<ITaxaDeJurosSeed, TaxaDeJurosSeed>()
                    .AddScoped<ITaxaDeJurosRepository, TaxaDeJurosRepository>()
                    .AddScoped<IUnitOfWork, UnitOfWork>();

        public static IServiceCollection AddTaxasDbContext(this IServiceCollection services) =>
            services.AddDbContext<TaxasDbContext>(opt => opt.UseInMemoryDatabase("Taxas"));
    }
}