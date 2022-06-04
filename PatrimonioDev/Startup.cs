using Aplicacao;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using PatrimonioDev.Configuration;
using Persistence;
using System;
using System.IO;

namespace PatrimonioDev
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

            services.AddCors();

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddServiceInjection();

            services.AddControllers();
            services.AddAuthenticationConfiguration(Configuration);

            services.AddSwaggerConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod().SetIsOriginAllowed((host) => true);
            });

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
                RequestPath = new PathString("/Resources")
            });

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
