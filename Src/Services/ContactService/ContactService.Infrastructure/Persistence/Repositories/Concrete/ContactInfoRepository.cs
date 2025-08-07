using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.Context;
using ContactService.Infrastructure.Persistence.Repositories.Abstract;

namespace ContactService.Infrastructure.Persistence.Repositories.Concrete
{
    public class ContactInfoRepository : BaseRepository<ContactInfo>, IContactInfoRepository
    {
        public ContactInfoRepository(ContactServiceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
