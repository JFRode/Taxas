using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Taxas.API.Extensions
{
    public static class Swagger
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Taxas.API",
                    Version = "v1",
                    Description = "API de consulta de taxas para cálculo",
                    TermsOfService = new Uri("https://github.com/JFRode/Taxas/blob/master/LICENSE"),
                    Contact = new OpenApiContact
                    {
                        Name = "João Felipe Gonçalves",
                        Email = "joaofelipe.rode@gmail.com",
                        Url = new Uri("https://github.com/JFRode"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://github.com/JFRode/Taxas/blob/master/LICENSE"),
                    }
                });
            });
    }
}