using ContactService.Application.Dtos.ContactInfo;
using ContactService.Application.Dtos.ExternalClients.Report;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.ContactInfo.Queries
{
    public class GetReportDataQuery : IRequest<ResultDataList<ReportResultDto>>
    {
        public GetReportDataQuery()
        {
        }
    }
}
