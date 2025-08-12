using ContactService.Application.Features.ContactInfo.Commands;
using ContactService.Infrastructure.Persistence.Abstract.UnitOfWorks;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.ContactInfo.Handlers
{
    public class UpdateContactInfoCommandHandler : IRequestHandler<UpdateContactInfoCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateContactInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var existingContactInfo = await _unitOfWork.ContactInfoRepository.GetByIdAsync(request.ContactInfo.Id);
                if (existingContactInfo == null)
                    return Result<int>.FailureResult("Contact Info not found.", ResultCode.NotFound);

                // Burada Type ve Content güncellemesi yapılacak.
                existingContactInfo.Content = request.ContactInfo.Content;
                existingContactInfo.UpdatedAt = DateTime.UtcNow;
                existingContactInfo.IsActive = request.ContactInfo.IsActive;
                existingContactInfo.Type = request.ContactInfo.Type;
                _unitOfWork.ContactInfoRepository.UpdateAsync(existingContactInfo);
                var response = await _unitOfWork.SaveChangesAsync();
                if (response > 0)
                {
                    await _unitOfWork.CommitAsync();
                    return Result<int>.SuccessResult(existingContactInfo.Id);
                }
                else
                {
                    await _unitOfWork.RollbackAsync();
                    return Result<int>.FailureResult("Failed to update contact info.", ResultCode.Error);
                }
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<int>.FailureResult($"An error occurred while updating contact info: {ex.Message}", ResultCode.Error);
            }
        }
    }
}
