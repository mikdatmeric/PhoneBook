using ContactService.Application.Dtos.Person;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.Person.Commands
{
    public class DeletePersonCommand : IRequest<Result<int>>
    {
        public DeletePersonDto Person { get; set; }
        public DeletePersonCommand(DeletePersonDto deletePersonDto)
        {
            Person = deletePersonDto ?? throw new ArgumentNullException(nameof(deletePersonDto), "DeletePersonDto cannot be null");

        }
    }
}
