using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ContactService.Persistence.Context
{
    public class ContactServiceDbContextFactory : IDesignTimeDbContextFactory<ContactServiceDbContext>
    {
        public ContactServiceDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ConctactService.API"))
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            var connectionString = configuration.GetConnectionString("ContactServiceDbConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ContactServiceDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ContactServiceDbContext(optionsBuilder.Options);
        }
    }
}
