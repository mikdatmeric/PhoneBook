using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;
using ReportService.Application.Dtos;

namespace ContactService.Application.Features.Person.Commands
{
    public class CompleteReportCommand : IRequest<Result>
    {
        public CompleteReportDto ReportDto { get; set; }
        public CompleteReportCommand(CompleteReportDto reportDto)
        {
            ReportDto = reportDto ?? throw new ArgumentNullException(nameof(reportDto), "ReportDto cannot be null");
        }
    }
}
