using ContactService.Infrastructure.Persistence.Context;
using ContactService.Infrastructure.Persistence.Repositories.Abstract;
using PhoneBook.Core.Abstractions;
using PhoneBook.Core.Abstractions.Repositories;
using PhoneBook.Core.Abstractions.UnitOfWorks;
namespace ContactService.Persistence.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactServiceDbContext _context;

        public UnitOfWork(ContactServiceDbContext context)
        {
            _context = context;
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
