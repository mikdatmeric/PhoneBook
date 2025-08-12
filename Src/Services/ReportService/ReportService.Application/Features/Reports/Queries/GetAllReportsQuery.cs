using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;
using ReportService.Application.Dtos;

namespace ReportService.Application.Features.Reports.Queries
{
    public class GetAllReportsQuery : IRequest<ResultDataList<ReportSummaryDto>>
    {
    }
}
