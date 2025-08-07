using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.Context;
using ContactService.Infrastructure.Persistence.Repositories.Abstract;

namespace ContactService.Infrastructure.Persistence.Repositories.Concrete
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(ContactServiceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
