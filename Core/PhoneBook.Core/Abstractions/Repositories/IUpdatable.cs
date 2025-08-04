namespace PhoneBook.Core.Abstractions.Repositories
{
    public interface IUpdatable<T> where T : class, IEntity
    {
        Task UpdateAsync(T entity);
    }
}
