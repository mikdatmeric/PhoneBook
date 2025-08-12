using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Concrete.Utulities.Results;
using ReportService.Application.Concrete.Dtos;
using ReportService.Application.Concrete.Features.Reports.Queries;
using ReportService.Application.Abstract.Persistence.UnitOfWorks;

namespace ReportService.Application.Concrete.Features.Reports.Handlers
{
    public class GetAllReportsQueryHandler : IRequestHandler<GetAllReportsQuery, ResultDataList<ReportSummaryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllReportsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultDataList<ReportSummaryDto>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
        {

            try
            {
                var reports = await _unitOfWork.ReportRepository.GetAllQueryable()
                                                                .Select(g => new ReportSummaryDto
                                                                {
                                                                    Id = g.Id,
                                                                    ReportCode = g.ReportCode,
                                                                    RequestedAt = g.RequestedAt,
                                                                    Status = g.Status,
                                                                }).ToListAsync(cancellationToken);

                return ResultDataList<ReportSummaryDto>.SuccessResult(reports);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                return ResultDataList<ReportSummaryDto>.FailureResult("An error occurred while get all reports.", ResultCode.Error);
            }

        }
    }
}
