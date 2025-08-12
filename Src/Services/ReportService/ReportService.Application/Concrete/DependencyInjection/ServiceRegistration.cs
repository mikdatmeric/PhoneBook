using Microsoft.Extensions.DependencyInjection;
using ReportService.Application.Abstract.Services;
using ReportService.Application.Concrete.Services;

namespace ReportService.Application.Concrete.DependencyInjection
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IReportService, ReportManager>();

            return services;
        }


    }
}
