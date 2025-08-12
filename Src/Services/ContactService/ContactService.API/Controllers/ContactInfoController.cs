using ContactService.Application.Dtos.ContactInfo;
using ContactService.Application.Dtos.ExternalClients.Report;
using ContactService.Application.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpPost]
        public async Task<Result<int>> CreateContactInfo([FromBody] List<CreateContactInfoDto> contactInfosDto)
        {
            var result = await _contactInfoService.CreateContactInfoAsync(contactInfosDto);
            return result;
        }

        [HttpPut]
        public async Task<Result<int>> UpdateContactInfo([FromBody] UpdateContactInfoDto contactInfoDto)
        {
            var result = await _contactInfoService.UpdateContactInfoAsync(contactInfoDto);
            return result;
        }

        [HttpPost]
        public async Task<Result<int>> DeleteContactInfo(DeleteContactInfoDto deleteContactInfoDto)
        {
            var result = await _contactInfoService.DeleteContactInfoAsync(deleteContactInfoDto);
            return result;
        }

        [HttpPost]
        public async Task<ResultDataList<ContactInfoDto>> GetContactInfosByPersonId(GetContactInfosByPersonIdRequestDto requestDto)
        {
            var result = await _contactInfoService.GetContactInfosByPersonIdAsync(requestDto);
            return result;
        }

        [HttpPost]
        public async Task<Result<ContactInfoDto>> GetContactInfoById(GetContactInfoByIdRequestDto getContactInfoByIdRequestDto)
        {
            var result = await _contactInfoService.GetContactInfoByIdAsync(getContactInfoByIdRequestDto);
            return result;
        }
        [HttpPost]
        public async Task<ResultDataList<ReportResultDto>> GetReportData()
        {
            var result = await _contactInfoService.GetReportDataAsync();
            return result;
        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IContactInfoService _contactInfoService;

        public ReportController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpPost]
        public async Task<Result<int>> CreateReportRequest([FromBody] List<CreateContactInfoDto> contactInfosDto)
        {
            var result = await _contactInfoService.CreateContactInfoAsync(contactInfosDto);
            return result;
        }

        [HttpPut]
        public async Task<Result<int>> Complete([FromBody] UpdateContactInfoDto contactInfoDto)
        {
            var result = await _contactInfoService.UpdateContactInfoAsync(contactInfoDto);
            return result;
        }

        [HttpPost]
        public async Task<Result<int>> GetAllReportsAsync(DeleteContactInfoDto deleteContactInfoDto)
        {
            var result = await _contactInfoService.DeleteContactInfoAsync(deleteContactInfoDto);
            return result;
        }

        [HttpPost]
        public async Task<ResultDataList<ContactInfoDto>> GetReportById(GetContactInfosByPersonIdRequestDto requestDto)
        {
            var result = await _contactInfoService.GetContactInfosByPersonIdAsync(requestDto);
            return result;
        }

        [HttpPost]
        public async Task<Result<ContactInfoDto>> GetContactInfoById(GetContactInfoByIdRequestDto getContactInfoByIdRequestDto)
        {
            var result = await _contactInfoService.GetContactInfoByIdAsync(getContactInfoByIdRequestDto);
            return result;
        }
    }
}
