using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;
using ReportService.Application.Abstract.Persistence.UnitOfWorks;
using ReportService.Application.Concrete.Features.Reports.Commands;
using System.Text.Json;
using static ReportService.Domain.Enums.Enums;

namespace ReportService.Application.Concrete.Features.Reports.Handlers
{
    public class CompleteReportCommandHandler : IRequestHandler<CompleteReportCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompleteReportCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CompleteReportCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var reportEntity = _unitOfWork.ReportRepository.FindAsync(x => x.ReportCode == request.ReportDto.ReportCode).Result.FirstOrDefault();
                if (reportEntity == null)
                {
                    return Result.FailureResult("Report not found.", ResultCode.NotFound);
                }
                reportEntity.UpdatedAt = DateTime.UtcNow;
                reportEntity.Status = ReportStatus.Completed;
                reportEntity.ResultJson = request.ReportDto.ReportResults != null && request.ReportDto.ReportResults.Count > 0 ? JsonSerializer.Serialize(request.ReportDto.ReportResults) : string.Empty;

                var response = await _unitOfWork.SaveChangesAsync();
                if (response > 0)
                {
                    await _unitOfWork.CommitAsync();
                    return Result.SuccessResult();
                }
                else
                {
                    await _unitOfWork.RollbackAsync();
                    return Result.FailureResult("Failed to complete the report.", ResultCode.Error);
                }
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                return Result.FailureResult("An error occurred while complete the report.", ResultCode.Error);
            }

        }
    }
}
