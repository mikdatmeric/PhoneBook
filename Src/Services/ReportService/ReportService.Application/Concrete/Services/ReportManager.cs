using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;
using ReportService.Application.Abstract.Services;
using ReportService.Application.Concrete.Dtos;
using ReportService.Application.Concrete.Features.Reports.Commands;
using ReportService.Application.Concrete.Features.Reports.Queries;

namespace ReportService.Application.Concrete.Services
{
    public class ReportManager : IReportService
    {
        private readonly IMediator _mediator;

        public ReportManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<Result> CompleteReportAsync(CompleteReportDto completeReportDto, CancellationToken ct = default)
        {
            var command = new CompleteReportCommand(completeReportDto);
            return _mediator.Send(command);
        }

        public Task<Result<Guid>> CreateReportRequestAsync(CancellationToken ct = default)
        {
            var command = new CreateReportRequestCommand();
            return _mediator.Send(command);
        }

        public Task<ResultDataList<ReportSummaryDto>> GetAllReportsAsync(CancellationToken ct = default)
        {
            var command = new GetAllReportsQuery();
            return _mediator.Send(command);
        }

        public Task<Result<ReportDetailDto>> GetReportByIdAsync(int reportId, CancellationToken ct = default)
        {
            var command = new GetReportByIdQuery(reportId);
            return _mediator.Send(command);
        }
        public Task<Result<ReportDetailDto>> GetReportByReportCodeAsync(Guid reportCode, CancellationToken ct = default)
        {
            var command = new GetReportByReportCodeQuery(reportCode);
            return _mediator.Send(command);
        }
    }
}
