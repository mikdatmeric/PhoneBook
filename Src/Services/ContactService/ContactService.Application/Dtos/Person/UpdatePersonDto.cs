using PhoneBook.Core.Abstractions;

namespace ContactService.Application.Dtos.Person
{
    public class UpdatePersonDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public bool IsActive { get; set; }
    }
}
