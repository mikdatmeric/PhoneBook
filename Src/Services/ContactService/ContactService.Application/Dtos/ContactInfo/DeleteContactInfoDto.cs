using PhoneBook.Core.Abstractions;

namespace ContactService.Application.Dtos.ContactInfo
{
    public class DeleteContactInfoDto : IDto
    {
        public int Id { get; set; }
    }
}
