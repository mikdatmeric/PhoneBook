using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;
using ReportService.Application.Dtos;

namespace ReportService.Application.Features.Reports.Queries
{
    public class GetReportByReportCodeQuery : IRequest<Result<ReportDetailDto>>
    {
        public Guid ReportCode { get; set; }
        public GetReportByReportCodeQuery(Guid reportCode)
        {
            ReportCode = reportCode;
        }
    }
}
