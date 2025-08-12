using ContactService.Application.Dtos.ContactInfo;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.ContactInfo.Queries
{
    public class GetContactInfoByIdQuery : IRequest<Result<ContactInfoDto>>
    {
        public GetContactInfoByIdRequestDto GetContactInfoByIdRequestDto { get; set; }

        public GetContactInfoByIdQuery(GetContactInfoByIdRequestDto requestDto)
        {
            GetContactInfoByIdRequestDto = requestDto ?? throw new ArgumentNullException(nameof(requestDto), "Request DTO cannot be null.");
        }
    }
}
