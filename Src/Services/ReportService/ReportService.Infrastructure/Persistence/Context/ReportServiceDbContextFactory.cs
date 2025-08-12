using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ReportService.Infrastructure.Persistence.Context
{
    public class ReportServiceDbContextFactory : IDesignTimeDbContextFactory<ReportServiceDbContext>
    {
        public ReportServiceDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ReportService.API"))
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            var connectionString = configuration.GetConnectionString("ReportServiceDbConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ReportServiceDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ReportServiceDbContext(optionsBuilder.Options);
        }
    }
}
