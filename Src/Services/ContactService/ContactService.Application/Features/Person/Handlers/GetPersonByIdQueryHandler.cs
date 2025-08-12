using ContactService.Application.Dtos.ContactInfo;
using ContactService.Application.Dtos.Person;
using ContactService.Application.Features.Person.Queries;
using ContactService.Infrastructure.Persistence.Abstract.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.Person.Handlers
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Result<PersonDetailDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPersonByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<PersonDetailDto>> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                PersonDetailDto personDetailDto = new PersonDetailDto();
                var person = await _unitOfWork.PersonRepository
                    .GetAllQueryable()
                    .Include(p => p.ContactInfos)
                    .FirstOrDefaultAsync(p => p.Id == request.Dto.Id && p.IsActive == true, cancellationToken);

                if (person == null)
                    return Result<PersonDetailDto>.FailureResult("Person not found.", ResultCode.ValidationError);

                personDetailDto.Id = person.Id;
                personDetailDto.FirstName = person.FirstName;
                personDetailDto.LastName = person.LastName;
                personDetailDto.Company = person.Company;
                personDetailDto.IsActive = person.IsActive;
                personDetailDto.CreatedAt = person.CreatedAt;
                personDetailDto.UpdatedAt = person.UpdatedAt;

                if (person.ContactInfos != null && person.ContactInfos.Count > 0)
                {
                    personDetailDto.ContactInfos = person.ContactInfos.Select(ci => new ContactInfoDto
                    {
                        Id = ci.Id,
                        Type = ci.Type,
                        Content = ci.Content,
                        CreatedAt = ci.CreatedAt,
                        UpdatedAt = ci.UpdatedAt,
                        IsActive = ci.IsActive,
                        PersonId = ci.PersonId

                    }).ToList();
                }

                return Result<PersonDetailDto>.SuccessResult(personDetailDto);
            }
            catch (Exception ex)
            {
                return Result<PersonDetailDto>.FailureResult("An error occurred while selecting the person by id.", ResultCode.Error);
            }
        }
    }
}
