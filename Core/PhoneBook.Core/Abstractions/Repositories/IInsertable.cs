namespace PhoneBook.Core.Abstractions.Repositories
{
    public interface IInsertable<T> where T : class, IEntity
    {
        Task AddAsync(T entity);
    }
}
