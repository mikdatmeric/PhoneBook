namespace PhoneBook.Core.Abstractions.Repositories
{
    public interface IRepository<T> : ISelectable<T>, IInsertable<T>, IUpdatable<T>, IDeletable<T> where T : class, IEntity
    {
    }
}
