using ContactService.Application.Features.ContactInfo.Commands;
using ContactService.Infrastructure.Persistence.Abstract.UnitOfWorks;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.ContactInfo.Handlers
{
    public class DeleteContactInfoCommandHandler : IRequestHandler<DeleteContactInfoCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteContactInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(DeleteContactInfoCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var existingContactInfo = await _unitOfWork.ContactInfoRepository.GetByIdAsync(request.DeleteContactDto.Id);
                if (existingContactInfo == null)
                    return Result<int>.FailureResult("Contact Info not found.", ResultCode.NotFound);

                // Burada Type ve Content güncellemesi yapılacak.
                existingContactInfo.IsActive = false;
                existingContactInfo.UpdatedAt = DateTime.UtcNow;   
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
                    return Result<int>.FailureResult("Failed to delete contact info.", ResultCode.Error);
                }
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<int>.FailureResult($"An error occurred while deleting contact info: {ex.Message}", ResultCode.Error);
            }
        }
    }
}
