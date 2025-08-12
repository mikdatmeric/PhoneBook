using ContactService.Application.Features.Person.Commands;
using ContactService.Infrastructure.Persistence.Abstract.UnitOfWorks;
using ContactService.Infrastructure.Persistence.Repositories.Abstract;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.Person.Handlers
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var personEntity = new ContactService.Domain.Entities.Person
                {
                    FirstName = request.Person.FirstName,
                    LastName = request.Person.LastName,
                    Company = request.Person.Company,
                    CreatedAt = DateTime.UtcNow
                };
                if (request.Person.ContactInfos != null && request.Person.ContactInfos.Count > 0)
                {

                }
                await _unitOfWork.PersonRepository.AddAsync(personEntity);

                foreach (var item in request.Person.ContactInfos)
                {
                    await _unitOfWork.ContactInfoRepository.AddAsync(new ContactService.Domain.Entities.ContactInfo
                    {
                        Type = item.Type,
                        Content = item.Content,
                        PersonId = personEntity.Id,
                        CreatedAt = DateTime.UtcNow,
                    });
                }

                var response = await _unitOfWork.SaveChangesAsync();
                if (response > 0)
                {
                    await _unitOfWork.CommitAsync();
                    return Result<int>.SuccessResult(personEntity.Id);
                }
                else
                {
                    await _unitOfWork.RollbackAsync();
                    return Result<int>.FailureResult("Failed to create the person.", ResultCode.Error);
                }
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                return Result<int>.FailureResult("An error occurred while creating the person.",ResultCode.Error);
            }

        }
    }
}
