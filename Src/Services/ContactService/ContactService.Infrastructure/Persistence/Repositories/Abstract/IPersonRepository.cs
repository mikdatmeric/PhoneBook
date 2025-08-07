using ContactService.Domain.Entities;
using PhoneBook.Core.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Infrastructure.Persistence.Repositories.Abstract
{
    public interface IPersonRepository : IRepository<Person>
    {
    }
}
