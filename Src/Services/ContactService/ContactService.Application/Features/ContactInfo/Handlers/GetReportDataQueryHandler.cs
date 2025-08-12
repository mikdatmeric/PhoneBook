using ContactService.Application.Dtos.ExternalClients.Report;
using ContactService.Application.Features.ContactInfo.Queries;
using ContactService.Infrastructure.Persistence.Abstract.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Concrete.Utulities.Results;
using static ContactService.Domain.Enums.Enums;

namespace ContactService.Application.Features.ContactInfo.Handlers
{
    public class GetReportDataQueryHandler : IRequestHandler<GetReportDataQuery, ResultDataList<ReportResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetReportDataQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ResultDataList<ReportResultDto>> Handle(GetReportDataQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<ReportResultDto> reportResults = new List<ReportResultDto>();
                var contactInfos = _unitOfWork.ContactInfoRepository.GetAllQueryable();

                reportResults = await contactInfos.Where(ci => ci.Type == ContactInfoType.Location && ci.IsActive)
                                                  .GroupBy(ci => ci.Content)
                                                  .Select(g => new ReportResultDto
                                                  {
                                                      Location = g.Key!,
                                                      PersonCount = g.Select(x => x.PersonId).Distinct().Count(),
                                                      PhoneCount = contactInfos
                                                          .Where(p => p.Type == ContactInfoType.Phone &&
                                                                      g.Select(loc => loc.PersonId).Contains(p.PersonId))
                                                          .Count()
                                                  }).ToListAsync(cancellationToken);

                return ResultDataList<ReportResultDto>.SuccessResult(reportResults);
            }
            catch (Exception ex)
            {
                return ResultDataList<ReportResultDto>.FailureResult("An error occurred while retrieving report data information.", ResultCode.Error);
            }
        }
    }
}
