using PhoneBook.Core.Abstractions.Repositories;
using ReportService.Domain.Entities;


namespace ReportService.Application.Abstract.Persistence.Repositories
{
    public interface IReportRepository : IRepository<Report>
    {
    }
}
