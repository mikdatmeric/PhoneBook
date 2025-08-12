using PhoneBook.Core.Abstractions;

namespace ContactService.Application.Dtos.ContactInfo
{
    public class GetContactInfosByPersonIdRequestDto : IDto
    {
        public int PersonId { get; set; }
    }
}
