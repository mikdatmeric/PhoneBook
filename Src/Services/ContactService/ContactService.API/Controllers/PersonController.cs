using ContactService.Application.Dtos.Person;
using ContactService.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<Result<int>> CreatePerson([FromBody] CreatePersonDto personDto)
        {
            var result = await _personService.CreatePersonAsync(personDto);
            return result;
        }

        [HttpPut]
        public async Task<Result<int>> UpdatePerson([FromBody] UpdatePersonDto dto)
        {
            var result = await _personService.UpdatePersonAsync(dto);
            return result;
        }

        [HttpDelete]
        public async Task<Result<int>> DeletePerson([FromBody] DeletePersonDto dto)
        {
            var result = await _personService.DeletePersonAsync(dto);
            return result;
        }

        [HttpGet]
        public async Task<ResultDataList<PersonDto>> GetAllPersons()
        {
            var result = await _personService.GetAllPersonsAsync();
            return result;
        }

        [HttpPost]
        public async Task<Result<PersonDetailDto>> GetPersonById([FromBody] GetPersonByIdRequestDto dto)
        {
            var result = await _personService.GetPersonByIdAsync(dto);
            return result;
        }
    }
}
