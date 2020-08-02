using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Taxas.API.Extensions;
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

            services.AddSwaggerService();
            services.AddAuthenticationService();
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
    }
}