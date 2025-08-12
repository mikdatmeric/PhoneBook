using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ReportService.Application.Concrete.Features.Reports.Commands
{
    public class CreateReportRequestCommand : IRequest<Result<Guid>>
    {
        public CreateReportRequestCommand()
        {

        }
    }
}
