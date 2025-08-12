using ContactService.Application.Features.ContactInfo.Commands;
using ContactService.Infrastructure.Persistence.Abstract.UnitOfWorks;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.ContactInfo.Handlers
{
    public class CreateContactInfoCommandHandler : IRequestHandler<CreateContactInfoCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateContactInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                int response = 0;
                if (request.ContactInfos == null && request.ContactInfos.Count <= 0)
                    return Result<int>.FailureResult("Contact information cannot be null.", ResultCode.ValidationError);
                foreach (var contactInfo in request.ContactInfos)
                {
                    var person = await _unitOfWork.PersonRepository.GetByIdAsync(contactInfo.PersonId);
                    if (person == null)
                        return Result<int>.FailureResult("Person not found.", ResultCode.NotFound);

                    var contactInfoEntity = new ContactService.Domain.Entities.ContactInfo
                    {
                        PersonId = contactInfo.PersonId,
                        Type = contactInfo.Type,
                        Content = contactInfo.Content,
                    };
                    _unitOfWork.ContactInfoRepository.AddAsync(contactInfoEntity);
                }
                response = await _unitOfWork.SaveChangesAsync();
                if (response > 0)
                {
                    await _unitOfWork.CommitAsync();
                    return Result<int>.SuccessResult(response);
                }
                else
                {
                    await _unitOfWork.RollbackAsync();
                    return Result<int>.FailureResult("Failed to create contact information.", ResultCode.Error);
                }
                
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<int>.FailureResult($"An error occurred while creating contact information: {ex.Message}", ResultCode.Error);
            }
        }
    }
}
