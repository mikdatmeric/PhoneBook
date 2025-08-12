using ContactService.Application.Features.Person.Commands;
using ContactService.Infrastructure.Persistence.Abstract.UnitOfWorks;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.Person.Handlers
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var existingPerson = await _unitOfWork.PersonRepository.GetByIdAsync(request.Person.Id);
                if (existingPerson == null)
                    return Result<int>.FailureResult("Person not found.", ResultCode.ValidationError);

                existingPerson.FirstName = request.Person.FirstName;
                existingPerson.LastName = request.Person.LastName;
                existingPerson.Company = request.Person.Company;
                existingPerson.UpdatedAt = DateTime.UtcNow;
                
                _unitOfWork.PersonRepository.UpdateAsync(existingPerson);
                var response = await _unitOfWork.SaveChangesAsync();
                if (response > 0)
                {
                    await _unitOfWork.CommitAsync();
                    return Result<int>.SuccessResult(existingPerson.Id);
                }
                else
                {
                    await _unitOfWork.RollbackAsync();
                    return Result<int>.FailureResult("Failed to update the person.", ResultCode.Error);
                }
                
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<int>.FailureResult("An error occurred while updating the person.", ResultCode.Error);
            }
        }
    }
}
