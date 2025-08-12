using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Concrete.Utulities.Results;
using ReportService.Application.Concrete.Dtos;
using ReportService.Application.Concrete.Features.Reports.Queries;
using ReportService.Application.Abstract.Persistence.UnitOfWorks;
using System.Text.Json;

namespace ReportService.Application.Concrete.Features.Reports.Handlers
{
    public class GetReportByReportCodeQueryHandler : IRequestHandler<GetReportByReportCodeQuery, Result<ReportDetailDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetReportByReportCodeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Result<ReportDetailDto>> Handle(GetReportByReportCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var jsonOpts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var report = await _unitOfWork.ReportRepository.GetAllQueryable().Select(g => new ReportDetailDto
                {
                    Id = g.Id,
                    ReportCode = g.ReportCode,
                    RequestedAt = g.RequestedAt,
                    Status = g.Status,
                    Data = string.IsNullOrEmpty(g.ResultJson) ? new List<ReportResultDto>() : JsonSerializer.Deserialize<List<ReportResultDto>>(g.ResultJson, jsonOpts)
                }).FirstOrDefaultAsync(x => x.ReportCode == request.ReportCode, cancellationToken);

                return Result<ReportDetailDto>.SuccessResult(report);
            }
            catch (Exception ex)
            {
                return Result<ReportDetailDto>.FailureResult("An error occurred while retrieving report data information.", ResultCode.Error);
            }
        }
    }
}
