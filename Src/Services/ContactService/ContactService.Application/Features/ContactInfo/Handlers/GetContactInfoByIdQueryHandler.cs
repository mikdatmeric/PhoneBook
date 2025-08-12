using ContactService.Application.Dtos.ContactInfo;
using ContactService.Application.Features.ContactInfo.Queries;
using ContactService.Infrastructure.Persistence.Abstract.UnitOfWorks;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.ContactInfo.Handlers
{
    public class GetContactInfoByIdQueryHandler : IRequestHandler<GetContactInfoByIdQuery, Result<ContactInfoDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetContactInfoByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ContactInfoDto>> Handle(GetContactInfoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var contactInfo = await _unitOfWork.ContactInfoRepository.GetByIdAsync(request.GetContactInfoByIdRequestDto.Id);
                if (contactInfo == null || contactInfo.IsActive == false)
                {
                    return Result<ContactInfoDto>.FailureResult("ContactInfo not found.", ResultCode.NotFound);
                }

                var contactInfoDto = new ContactInfoDto
                {
                    Id = contactInfo.Id,
                    PersonId = contactInfo.PersonId,
                    Type = contactInfo.Type,
                    Content = contactInfo.Content,
                    IsActive = contactInfo.IsActive,
                    CreatedAt = contactInfo.CreatedAt,
                    UpdatedAt = contactInfo.UpdatedAt
                };

                return Result<ContactInfoDto>.SuccessResult(contactInfoDto);
            }
            catch (Exception ex)
            {
                return Result<ContactInfoDto>.FailureResult($"An error occurred while retrieving contact info: {ex.Message}", ResultCode.Error);
            }
        }
    }

}
