using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Taxas.Application.Interfaces.Services;
using Taxas.Application.Interfaces.Validators;
using Taxas.Application.Mappers;
using Taxas.Application.Services;
using Taxas.Application.Validators;

namespace Taxas.Application
{
    public static class IocApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services.AddScoped<ITaxaDeJurosService, TaxaDeJurosService>()
                    .AddScoped<ITaxaDeJurosValidator, TaxaDeJurosValidator>();

        public static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(MappingProfile));

        public static IMvcCoreBuilder AddFluentValidation(this IMvcCoreBuilder builder) =>
            builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TaxaDeJurosValidator>());
    }
}