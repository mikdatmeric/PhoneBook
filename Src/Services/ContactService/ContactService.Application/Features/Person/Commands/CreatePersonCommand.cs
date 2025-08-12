using ContactService.Application.Dtos.Person;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.Person.Commands
{
    public class CreatePersonCommand : IRequest<Result<int>>
    {
        public CreatePersonDto Person { get; set; }
        public CreatePersonCommand(CreatePersonDto createPersonDto )
        {
            Person = createPersonDto ?? new CreatePersonDto();

        }
    }
}
