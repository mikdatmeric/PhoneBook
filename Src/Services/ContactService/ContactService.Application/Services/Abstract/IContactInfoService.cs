using ContactService.Application.Dtos.ContactInfo;
using ContactService.Application.Dtos.ExternalClients.Report;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Services.Abstract
{
    public interface IContactInfoService
    {
        Task<Result<int>> CreateContactInfoAsync(List<CreateContactInfoDto> dto);
        Task<Result<int>> UpdateContactInfoAsync(UpdateContactInfoDto dto);
        Task<Result<int>> DeleteContactInfoAsync(DeleteContactInfoDto dto);
        Task<Result<ContactInfoDto>> GetContactInfoByIdAsync(GetContactInfoByIdRequestDto dto);
        Task<ResultDataList<ContactInfoDto>> GetContactInfosByPersonIdAsync(GetContactInfosByPersonIdRequestDto dto);
        Task<ResultDataList<ReportResultDto>> GetReportDataAsync();
    }
}
