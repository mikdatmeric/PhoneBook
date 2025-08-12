using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Infrastructure.Persistence.Context;
using ReportService.Infrastructure.Persistence.Repositories.Abstract;
using ReportService.Infrastructure.Persistence.Repositories.Concrete;
using ReportService.Infrastructure.Persistence.UnitOfWorks.Abstract;
using ReportService.Infrastructure.Persistence.UnitOfWorks.Concrete;
namespace ReportService.Infrastructure.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext Injection
            services.AddDbContext<ReportServiceDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Repository Injection
            services.AddScoped<IReportRepository, ReportRepository>();

            // Unit of Work Injection
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
