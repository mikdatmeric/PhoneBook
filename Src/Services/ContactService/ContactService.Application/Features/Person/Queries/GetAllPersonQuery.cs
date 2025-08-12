using ContactService.Application.Dtos.Person;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.Person.Queries
{
    public class GetAllPersonQuery : IRequest<ResultDataList<PersonDto>>
    {
    }
}
