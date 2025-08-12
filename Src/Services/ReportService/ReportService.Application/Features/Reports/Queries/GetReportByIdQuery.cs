using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;
using ReportService.Application.Dtos;

namespace ReportService.Application.Features.Reports.Queries
{
    public class GetReportByIdQuery : IRequest<Result<ReportDetailDto>>
    {
        public int Id { get; set; }
        public GetReportByIdQuery(int id)
        {
            Id = id;
        }
    }
}
