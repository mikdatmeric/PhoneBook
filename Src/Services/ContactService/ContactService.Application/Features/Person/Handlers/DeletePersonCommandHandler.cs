using ContactService.Application.Features.Person.Commands;
using ContactService.Infrastructure.Persistence.Abstract.UnitOfWorks;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.Person.Handlers
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var person = await _unitOfWork.PersonRepository.GetByIdAsync(request.Person.Id);
                if (person == null)
                    return Result<int>.FailureResult("Person not found.", ResultCode.NotFound);

                person.UpdatedAt = DateTime.UtcNow;
                person.IsActive = false;
                _unitOfWork.PersonRepository.UpdateAsync(person);
                var response = await _unitOfWork.SaveChangesAsync();
                if (response > 0)
                {
                    await _unitOfWork.CommitAsync();
                    return Result<int>.SuccessResult(person.Id);
                }
                else
                {
                    await _unitOfWork.RollbackAsync();
                    return Result<int>.FailureResult("Failed to delete the person.", ResultCode.Error);
                }
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<int>.FailureResult("An error occurred while deleting the person.", ResultCode.Error);
            }
        }
    }
}
