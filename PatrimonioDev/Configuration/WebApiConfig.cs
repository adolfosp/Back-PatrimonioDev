using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using PatrimonioDev.Extension;
using System.IO;

namespace PatrimonioDev.Configuration
{
    public static class WebApiConfig
    {

        public static IApplicationBuilder UseWebApiConfiguration(this IApplicationBuilder app)
        {

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod().SetIsOriginAllowed((host) => true);
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
