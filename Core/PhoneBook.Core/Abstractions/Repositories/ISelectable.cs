using System.Linq.Expressions;

namespace PhoneBook.Core.Abstractions.Repositories
{
    public interface ISelectable<T> where T : class, IEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAllQueryable();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
