using ContactService.Application.Dtos.ContactInfo;
using PhoneBook.Core.Abstractions;

namespace ContactService.Application.Dtos.Person
{
    public class PersonDetailDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<ContactInfoDto> ContactInfos { get; set; }
        
    }
}
