using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Concrete.Utulities.Results;
using ReportService.Application.Dtos;
using ReportService.Application.Services.Abstract;

namespace ReportService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;

        }
        public async Task<Result> CompleteReportAsync(CompleteReportDto completeReportDto, CancellationToken ct = default)
        {
            var result = await _reportService.CompleteReportAsync(completeReportDto,ct);
            return result;
        }
        public async Task<Result<Guid>> CreateReportRequestAsync(CancellationToken ct = default)
        {
            var result = await _reportService.CreateReportRequestAsync(ct);
            return result;
        }

        public async Task<ResultDataList<ReportSummaryDto>> GetAllReportsAsync(CancellationToken ct = default)
        {
            var result = await _reportService.GetAllReportsAsync(ct);
            return result;
        }
        public async Task<Result<ReportDetailDto>> GetReportByIdAsync(int reportId, CancellationToken ct = default)
        {
            var result = await _reportService.GetReportByIdAsync(reportId, ct);
            return result;
        }
        public async Task<Result<ReportDetailDto>> GetReportByReportCodeAsync(Guid reportCode, CancellationToken ct = default)
        {
            var result = await _reportService.GetReportByReportCodeAsync(reportCode, ct);
            return result;
        }
    }
}
