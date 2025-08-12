using PhoneBook.Core.Abstractions;

namespace ContactService.Application.Dtos.ContactInfo
{
    public class GetContactInfoByIdRequestDto : IDto
    {
        public int Id { get; set; }
    }
}
