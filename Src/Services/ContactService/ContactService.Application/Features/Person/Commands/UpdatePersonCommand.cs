using ContactService.Application.Dtos.Person;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.Person.Commands
{
    public class UpdatePersonCommand : IRequest<Result<int>>
    {
        public UpdatePersonDto Person { get; set; }
        public UpdatePersonCommand(UpdatePersonDto updatePersonDto)
        {
            Person = updatePersonDto ?? throw new ArgumentNullException(nameof(updatePersonDto), "UpdatePersonDto cannot be null");
        }
    }
}
