using Aplicacao;
using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Persistence;
using System;
using System.IO;
using System.Linq;

namespace PatrimonioDev
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
            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUsuarioPermissaoPersistence, UsuarioPermissaoPersistence>();
            services.AddScoped<IUsuarioPersistence, UsuarioPersistence>();
            services.AddScoped<IEquipamentoPersistence, EquipamentoPersistence>();
            services.AddScoped<IPatrimonioPersistence, PatrimonioPersistence>();
            services.AddScoped<IPercaEquipamentoPersistence, PercaEquipamentoPersistence>();
            services.AddScoped<IMovimentacaoEquipamentoPersistence, MovimentacaoEquipamentoPersistence>();
            services.AddScoped<ICategoriaPersistence, CategoriaPersistence>();


            services.AddCors();

            services.AddControllers();
            //Versionning API

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "REST API",
                        Version = "v1",
                        Description = "REST API",
                        Contact = new OpenApiContact
                        {
                            Name = "Adolfo Poiatti",
                        }
                    });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "REST API - v1");
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(cors => cors.AllowAnyHeader()
                             .AllowAnyMethod()
                             .AllowAnyOrigin()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
        }
    }
}
