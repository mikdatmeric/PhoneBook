using PhoneBook.Core.Concrete.Utulities.Results;
using ReportService.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Services.Abstract
{
    public interface IReportService
    {
        Task<Result<Guid>> CreateReportRequestAsync(CancellationToken ct = default);
        Task<Result> CompleteReportAsync(CompleteReportDto completeReportDto, CancellationToken ct = default);
        Task<Result<ReportDetailDto>> GetReportByIdAsync(int reportId, CancellationToken ct = default);
        Task<Result<ReportDetailDto>> GetReportByReportCodeAsync(Guid reportCode, CancellationToken ct = default);
        Task<ResultDataList<ReportSummaryDto>> GetAllReportsAsync(CancellationToken ct = default);
    }
}
