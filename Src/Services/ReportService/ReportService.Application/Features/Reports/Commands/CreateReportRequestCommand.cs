using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.Person.Commands
{
    public class CreateReportRequestCommand : IRequest<Result<Guid>>
    {
        public CreateReportRequestCommand()
        {

        }
    }
}
