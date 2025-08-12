using PhoneBook.Core.Concrete;

namespace ContactService.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public ICollection<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();
    }
}
