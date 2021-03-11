using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TesteDesenvolvedor.Repository.Context;
using Microsoft.EntityFrameworkCore;
using TesteDesenvolvedor.Services.Interface;
using TesteDesenvolvedor.Services;
using TesteDesenvolvedor.Repository.Generic;
using TesteDesenvolvedor.Repository.Interface;
using TesteDesenvolvedor.Repository;

namespace TesteDesenvolvedor.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DataContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection")));

            services.AddControllers();

            services.AddScoped<IParadaService, ParadaService>();
            services.AddScoped<ILinhaService, LinhaService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IPosicaoVeiculoService, PosicaoVeiculoService>();


            services.AddScoped(typeof(IRepository), typeof(GenericRepository));
            services.AddScoped(typeof(IParadaRepository), typeof(ParadaRepository));
            services.AddScoped(typeof(IVeiculoRepository), typeof(VeiculoRepository));    
            services.AddScoped(typeof(ILinhaRepository), typeof(LinhaRepository));    
            services.AddScoped(typeof(IPosicaoVeiculoRepository), typeof(PosicaoVeiculoRepository));    
            
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Teste de Desenvolvedor .NET AIKO", 
                    Version = "v1", 
                    Description = "API desenvolvida para o teste de desenvolvedor .NET na AIKO Digital",
                    Contact = new OpenApiContact
                        {
                            Name = "Allison Sousa Bahls",
                            Url = new Uri("https://github.com/AllisonSBahls")
                        } });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste de Desenvolvedor .NET AIKO"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
