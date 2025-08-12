using ContactService.Application.Dtos.ContactInfo;
using ContactService.Application.Features.ContactInfo.Queries;
using ContactService.Infrastructure.Persistence.Abstract.UnitOfWorks;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.ContactInfo.Handlers
{
    public class GetContactInfosByPersonIdQueryHandler : IRequestHandler<GetContactInfosByPersonIdQuery, ResultDataList<ContactInfoDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetContactInfosByPersonIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ResultDataList<ContactInfoDto>> Handle(GetContactInfosByPersonIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<ContactInfoDto> contactInfoDtos = new List<ContactInfoDto>();
                var contactInfos = await _unitOfWork.ContactInfoRepository.FindAsync(x => x.PersonId == request.GetContactInfosByPersonIdQueryRequestDto.PersonId && x.IsActive == true);

                if (contactInfos == null || !contactInfos.Any())
                {
                    return ResultDataList<ContactInfoDto>.FailureResult("No contact info found for this person.", ResultCode.NotFound);
                }

                contactInfoDtos = contactInfos.Select(ci => new ContactInfoDto
                {
                    Id = ci.Id,
                    PersonId = ci.PersonId,
                    Type = ci.Type,
                    Content = ci.Content,
                    IsActive = ci.IsActive,
                    CreatedAt = ci.CreatedAt,
                    UpdatedAt = ci.UpdatedAt
                }).ToList();

                return ResultDataList<ContactInfoDto>.SuccessResult(contactInfoDtos);
            }
            catch (Exception ex)
            {
                return ResultDataList<ContactInfoDto>.FailureResult("An error occurred while retrieving contact information.", ResultCode.Error);
            }
        }
    }
}
