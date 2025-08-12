using PhoneBook.Core.Abstractions;

namespace ContactService.Application.Dtos.Person
{
    public class GetPersonByIdRequestDto : IDto
    {
        public int Id { get; set; }
    }
}
