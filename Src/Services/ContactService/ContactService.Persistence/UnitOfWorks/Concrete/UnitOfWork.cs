using ContactService.Persistence.Context;
using ContactService.Persistence.Repositories.Abstract;
using PhoneBook.Core.Abstractions;
using PhoneBook.Core.Abstractions.Repositories;
using PhoneBook.Core.Abstractions.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Persistence.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactServiceDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(ContactServiceDbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            var type = typeof(T);
            if (!_repositories.ContainsKey(type))
            {
                var repo = new Repository<T>(_context);
                _repositories[type] = repo;
            }

            return (IRepository<T>)_repositories[type];
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
