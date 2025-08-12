using ContactService.Application.Dtos.ContactInfo;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.ContactInfo.Queries
{
    public class GetContactInfosByPersonIdQuery : IRequest<ResultDataList<ContactInfoDto>>
    {
        public GetContactInfosByPersonIdRequestDto GetContactInfosByPersonIdQueryRequestDto { get; set; }

        public GetContactInfosByPersonIdQuery(GetContactInfosByPersonIdRequestDto getContactInfosByPersonIdQueryRequestDto)
        {
            GetContactInfosByPersonIdQueryRequestDto = getContactInfosByPersonIdQueryRequestDto;
        }
    }
}
