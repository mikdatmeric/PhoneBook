using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;
using ReportService.Application.Concrete.Features.Reports.Commands;
using ReportService.Domain.Entities;
using ReportService.Application.Abstract.Persistence.UnitOfWorks;
using static ReportService.Domain.Enums.Enums;

namespace ReportService.Application.Concrete.Features.Reports.Handlers
{
    public class CreateReportRequestCommandHandler : IRequestHandler<CreateReportRequestCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateReportRequestCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateReportRequestCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var reportEntity = new Report
                {
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    RequestedAt = DateTime.UtcNow,
                    ReportCode = Guid.NewGuid(),
                    Status = ReportStatus.Preparing
                };

                await _unitOfWork.ReportRepository.AddAsync(reportEntity);

                var response = await _unitOfWork.SaveChangesAsync();
                if (response > 0)
                {
                    await _unitOfWork.CommitAsync();
                    return Result<Guid>.SuccessResult(reportEntity.ReportCode);
                }
                else
                {
                    await _unitOfWork.RollbackAsync();
                    return Result<Guid>.FailureResult("Failed to create the report.", ResultCode.Error);
                }
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                return Result<Guid>.FailureResult("An error occurred while creating the report.", ResultCode.Error);
            }

        }
    }
}
