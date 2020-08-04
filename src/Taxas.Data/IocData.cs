using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Taxas.Application.Interfaces;
using Taxas.Application.Interfaces.Repositories;
using Taxas.Data.Context;
using Taxas.Data.Repositories;

namespace Taxas.Data
{
    public static class IocData
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services) =>
            services.AddScoped<ITaxaDeJurosRepository, TaxaDeJurosRepository>()
                    .AddScoped<IUnitOfWork, UnitOfWork>();

        public static IServiceCollection AddTaxasDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<TaxasDbContext>(opt => opt.UseSqlServer(connectionString));
    }
}