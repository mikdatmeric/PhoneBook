using ContactService.Infrastructure.Persistence.Repositories.Abstract;

namespace ContactService.Infrastructure.Persistence.Abstract.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository PersonRepository { get; }
        IContactInfoRepository ContactInfoRepository { get; }

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync();
    }
}
