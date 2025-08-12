using ContactService.Application.Dtos.ContactInfo;
using ContactService.Application.Dtos.ExternalClients.Report;
using ContactService.Application.Features.ContactInfo.Commands;
using ContactService.Application.Features.ContactInfo.Queries;
using ContactService.Application.Services.Abstract;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Services.Concrete
{
    public class ContactInfoManager : IContactInfoService
    {
        private readonly IMediator _mediator;

        public ContactInfoManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Result<int>> CreateContactInfoAsync(List<CreateContactInfoDto> createContactInfoDtos)
        {
            var command = new CreateContactInfoCommand(createContactInfoDtos);
            return await _mediator.Send(command);
        }

        public async Task<Result<int>> UpdateContactInfoAsync(UpdateContactInfoDto dto)
        {
            var command = new UpdateContactInfoCommand(dto);
            return await _mediator.Send(command);
        }

        public async Task<Result<int>> DeleteContactInfoAsync(DeleteContactInfoDto dto)
        {
            var command = new DeleteContactInfoCommand(dto);
            return await _mediator.Send(command);
        }
        public async Task<Result<ContactInfoDto>> GetContactInfoByIdAsync(GetContactInfoByIdRequestDto dto)
        {
            var query = new GetContactInfoByIdQuery(dto);
            return await _mediator.Send(query);
        }
        public async Task<ResultDataList<ContactInfoDto>> GetContactInfosByPersonIdAsync(GetContactInfosByPersonIdRequestDto dto)
        {
            var query = new GetContactInfosByPersonIdQuery(dto);
            return await _mediator.Send(query);
        }
        public async Task<ResultDataList<ReportResultDto>> GetReportDataAsync()
        {
            var query = new GetReportDataQuery();
            return await _mediator.Send(query);
        }
    }
}
