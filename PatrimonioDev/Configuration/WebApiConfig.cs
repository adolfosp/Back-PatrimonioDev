using Aplicacao;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using PatrimonioDev.Extension;
using System.IO;

namespace PatrimonioDev.Configuration
{
    public static class WebApiConfig
    {

        public static IServiceCollection AddWebApiConfiguration(this IServiceCollection services)
        {
            services.AddCors();

            services.AddApplication();

            services.AddControllers();

            return services;
        }


        public static IApplicationBuilder UseWebApiConfiguration(this IApplicationBuilder app)
        {

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader().
                        AllowAnyOrigin().
                        AllowAnyMethod().
                        SetIsOriginAllowed((host) => true);
            });

            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = p => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options => { options.UIPath = "/dashboard"; options.AddCustomStylesheet("Configuration\\HealthCheck\\patrimonio.css"); });

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
                RequestPath = new PathString("/Resources")
            });

            return app;
        }
    }
}
