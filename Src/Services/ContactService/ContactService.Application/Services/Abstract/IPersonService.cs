using ContactService.Application.Dtos.Person;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Services.Abstract
{
    public interface IPersonService
    {
        Task<Result<int>> CreatePersonAsync(CreatePersonDto dto);
        Task<Result<int>> UpdatePersonAsync(UpdatePersonDto dto);
        Task<Result<int>> DeletePersonAsync(DeletePersonDto dto);
        Task<ResultDataList<PersonDto>> GetAllPersonsAsync();
        Task<Result<PersonDetailDto>> GetPersonByIdAsync(GetPersonByIdRequestDto dto);
    }
}
