using ContactService.Domain.Entities;
using PhoneBook.Core.Abstractions.Repositories;

namespace ContactService.Infrastructure.Persistence.Repositories.Abstract
{
    public interface IContactInfoRepository : IRepository<ContactInfo>
    {

    }
}
