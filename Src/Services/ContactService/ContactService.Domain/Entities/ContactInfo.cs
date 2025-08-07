using PhoneBook.Core.Concrete;
using static ContactService.Domain.Enums.Enums;

namespace ContactService.Domain.Entities
{
    public class ContactInfo : BaseEntity
    {
        public int PersonId { get; set; }
        public ContactInfoType Type { get; set; }
        public string Content { get; set; } = string.Empty;

        public Person Person { get; set; }
    }
}
