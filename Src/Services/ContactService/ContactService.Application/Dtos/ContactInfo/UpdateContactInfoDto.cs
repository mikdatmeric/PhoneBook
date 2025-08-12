using PhoneBook.Core.Abstractions;
using static ContactService.Domain.Enums.Enums;

namespace ContactService.Application.Dtos.ContactInfo
{
    public class UpdateContactInfoDto : IDto
    {
        public int Id { get; set; }
        public ContactInfoType Type { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public int PersonId { get; set; }

    }
}
