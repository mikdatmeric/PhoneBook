using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;
using ReportService.Application.Concrete.Dtos;

namespace ReportService.Application.Concrete.Features.Reports.Queries
{
    public class GetAllReportsQuery : IRequest<ResultDataList<ReportSummaryDto>>
    {
    }
}
