using PhoneBook.Core.Abstractions;

namespace ContactService.Application.Dtos.Person
{
    public class DeletePersonDto : IDto
    {
        public int Id { get; set; }
    }
}
