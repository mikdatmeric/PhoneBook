using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Application.Abstract.Persistence.Repositories;
using ReportService.Application.Abstract.Persistence.UnitOfWorks;
using ReportService.Infrastructure.Concrete.Persistence.Context;
using ReportService.Infrastructure.Concrete.Persistence.Repositories;
using ReportService.Infrastructure.Concrete.Persistence.UnitOfWorks;
namespace ReportService.Infrastructure.Concrete.DependencyInjection
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
