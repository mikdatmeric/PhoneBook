using Microsoft.EntityFrameworkCore.Storage;
using ReportService.Infrastructure.Persistence.Context;
using ReportService.Infrastructure.Persistence.Repositories.Abstract;
using ReportService.Infrastructure.Persistence.Repositories.Concrete;
using ReportService.Infrastructure.Persistence.UnitOfWorks.Abstract;

namespace ReportService.Infrastructure.Persistence.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReportServiceDbContext _context;
        private IDbContextTransaction? _transaction;

        public IReportRepository ReportRepository { get; }

        public UnitOfWork(ReportServiceDbContext context)
        {
            _context = context;
            ReportRepository = new ReportRepository(_context);
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
