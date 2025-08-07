using ContactService.Domain.Entities;
using PhoneBook.Core.Abstractions.Repositories;

namespace ContactService.Persistence.Repositories.Abstract
{
    public interface IContactInfoRepository : IRepository<ContactInfo>
    {

    }
}
