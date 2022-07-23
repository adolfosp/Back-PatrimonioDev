using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistencia.Contexts;

namespace PatrimonioDev.Configuration
{
    public static class ConnectionString
    {
        public static void AddPersistenceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b =>
                    {
                        b.MigrationsAssembly("Persistencia");
                    }));

            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"));

            services.AddHealthChecksUI(options =>
            {
                options.SetEvaluationTimeInSeconds(5);
                options.MaximumHistoryEntriesPerEndpoint(10);
                options.AddHealthCheckEndpoint("API com Health Checks", "/health");
            }).AddInMemoryStorage();

        }
    }
}
