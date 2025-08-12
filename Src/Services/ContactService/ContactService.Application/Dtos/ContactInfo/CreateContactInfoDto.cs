using PhoneBook.Core.Abstractions;
using static ContactService.Domain.Enums.Enums;

namespace ContactService.Application.Dtos.ContactInfo
{
    public class CreateContactInfoDto : IDto
    {
        public int PersonId { get; set; }
        public ContactInfoType Type { get; set; } // Telefon, Email, Lokasyon
        public string Content { get; set; }
        public bool IsActive { get; set; } = true; // Varsayılan olarak aktif
    }
}
