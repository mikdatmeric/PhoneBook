using ContactService.Application.Dtos.ContactInfo;
using PhoneBook.Core.Abstractions;

namespace ContactService.Application.Dtos.Person
{
    public class CreatePersonDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public List<CreateContactInfoDto> ContactInfos { get; set; } = new List<CreateContactInfoDto>();
    }
}
