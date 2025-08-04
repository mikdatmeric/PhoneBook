using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.Abstractions.Repositories
{
    public interface IDeletable<T> where T : class, IEntity
    {
        Task DeleteAsync(T entity);
    }
}
