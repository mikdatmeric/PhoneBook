using ContactService.Application.Dtos.Person;
using ContactService.Application.Features.Person.Queries;
using ContactService.Infrastructure.Persistence.Abstract.UnitOfWorks;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.Person.Handlers
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, ResultDataList<PersonDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPersonQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultDataList<PersonDto>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<PersonDto> personDtos = new List<PersonDto>();
                var persons = await _unitOfWork.PersonRepository.FindAsync(x=> x.IsActive == true);
                if (persons != null && persons.Count() > 0)
                    return ResultDataList<PersonDto>.FailureResult("Person not found.", ResultCode.ValidationError);

                foreach (var item in persons)
                {
                    personDtos.Add(new PersonDto
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Company = item.Company,
                        IsActive = item.IsActive,
                        CreatedAt = item.CreatedAt,
                        UpdatedAt = item.UpdatedAt
                    });
                }
                return ResultDataList<PersonDto>.SuccessResult(personDtos, "Persons retrieved successfully.");

            }
            catch (Exception ex)
            {
                return ResultDataList<PersonDto>.FailureResult("An error occurred while selecting the person.", ResultCode.Error);
            }
        }
    }
}
