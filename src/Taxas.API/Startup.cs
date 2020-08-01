using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Threading.Tasks;
using Taxas.Application;
using Taxas.Data;
using Taxas.Data.Seed;

namespace Taxas.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApplicationServices();
            services.AddAutoMapper();
            services.AddMvcCore(options => options.SuppressAsyncSuffixInActionNames = false)
                .AddFluentValidation();

            services.AddDataServices();
            services.AddTaxasDbContext();

            ConfigureSwaggerService(services);
            ConfigureAuthenticationService(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            SeedDataBase(app);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taxas.API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SeedDataBase(IApplicationBuilder app)
        {
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var seed = serviceScopeFactory.ServiceProvider.GetService<ITaxaDeJurosSeed>();
            seed.Executar();
        }

        private void ConfigureSwaggerService(IServiceCollection services)
        {
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

        private void ConfigureAuthenticationService(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "TaxasAPI",
                        ValidAudience = "TaxasAPI",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine($"Token Inválido: {context.Exception.Message}");
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine($"Token Válido: {context.SecurityToken}");
                            return Task.CompletedTask;
                        }
                    };
                });
        }
    }
}