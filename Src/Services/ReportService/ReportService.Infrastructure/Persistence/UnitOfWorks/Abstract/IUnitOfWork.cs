using ReportService.Infrastructure.Persistence.Repositories.Abstract;

namespace ReportService.Infrastructure.Persistence.UnitOfWorks.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IReportRepository ReportRepository { get; }

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync();
    }
}
