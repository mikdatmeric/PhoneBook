using ContactService.Application.Dtos.Person;
using ContactService.Application.Features.Person.Commands;
using ContactService.Application.Features.Person.Queries;
using ContactService.Application.Services.Abstract;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Services.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IMediator _mediator;

        public PersonManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<Result<int>> CreatePersonAsync(CreatePersonDto dto)
        {
            var command = new CreatePersonCommand(dto);
            return _mediator.Send(command);
        }

        public Task<Result<int>> DeletePersonAsync(DeletePersonDto dto)
        {
            var command = new DeletePersonCommand(dto);
            return _mediator.Send(command);
        }

        public Task<ResultDataList<PersonDto>> GetAllPersonsAsync()
        {
            var query = new GetAllPersonQuery();
            return _mediator.Send(query);
        }

        public Task<Result<PersonDetailDto>> GetPersonByIdAsync(GetPersonByIdRequestDto dto)
        {
            var query = new GetPersonByIdQuery(dto);
            return _mediator.Send(query);
        }

        public Task<Result<int>> UpdatePersonAsync(UpdatePersonDto dto)
        {
            var command = new UpdatePersonCommand(dto);
            return _mediator.Send(command);
        }
    }
}
