using ContactService.Infrastructure.Persistence.Abstract.UnitOfWorks;
using ContactService.Infrastructure.Persistence.Context;
using ContactService.Infrastructure.Persistence.Repositories.Abstract;
using ContactService.Infrastructure.Persistence.Repositories.Concrete;
using Microsoft.EntityFrameworkCore.Storage;

namespace ContactService.Infrastructure.Persistence.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactServiceDbContext _context;
        private IDbContextTransaction? _transaction;

        public IPersonRepository PersonRepository { get; }
        public IContactInfoRepository ContactInfoRepository { get; }

        public UnitOfWork(ContactServiceDbContext context)
        {
            _context = context;
            PersonRepository = new PersonRepository(_context);
            ContactInfoRepository = new ContactInfoRepository(_context);
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
