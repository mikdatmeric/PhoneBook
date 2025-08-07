using ContactService.Infrastructure.Persistence.Context;
using ContactService.Infrastructure.Persistence.Repositories.Abstract;
using ContactService.Infrastructure.Persistence.Repositories.Concrete;
using ContactService.Persistence.UnitOfWorks.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Abstractions.UnitOfWorks;
namespace ContactService.Infrastructure.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext Injection
            services.AddDbContext<ContactServiceDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Repository Injection
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IContactInfoRepository, ContactInfoRepository>();

            // Unit of Work Injection
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
