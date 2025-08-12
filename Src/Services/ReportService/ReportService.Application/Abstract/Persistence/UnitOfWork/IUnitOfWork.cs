using ReportService.Application.Abstract.Persistence.Repositories;

namespace ReportService.Application.Abstract.Persistence.UnitOfWorks
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
