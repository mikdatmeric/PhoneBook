using PhoneBook.Core.Abstractions;
using PhoneBook.Core.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ReportService.Infrastructure.Persistence.Context;

namespace ReportService.Infrastructure.Persistence.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly ReportServiceDbContext _dbContext;

        public BaseRepository(ReportServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
