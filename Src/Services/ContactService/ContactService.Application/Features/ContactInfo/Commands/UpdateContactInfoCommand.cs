using ContactService.Application.Dtos.ContactInfo;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.ContactInfo.Commands
{
    public class UpdateContactInfoCommand : IRequest<Result<int>>
    {
        public UpdateContactInfoDto ContactInfo { get; set; }
        public UpdateContactInfoCommand(UpdateContactInfoDto updateContactInfoRequestDto)
        {
            ContactInfo = updateContactInfoRequestDto ?? new UpdateContactInfoDto();
        }
    }

}
