using ContactService.Application.Features.Person.Commands;
using MediatR;
using PhoneBook.Core.Abstractions;
using PhoneBook.Core.Concrete.Utulities.Results;
using ReportService.Application.Dtos;
using ReportService.Application.Features.Reports.Queries;
using ReportService.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Services.Concrete
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
