using ContactService.Application.Dtos.ContactInfo;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.ContactInfo.Commands
{
    public class DeleteContactInfoCommand : IRequest<Result<int>>
    {
        public DeleteContactInfoDto DeleteContactDto { get; set; }
        public DeleteContactInfoCommand(DeleteContactInfoDto deleteContactInfoRequestDto)
        {
            DeleteContactDto = deleteContactInfoRequestDto ?? new DeleteContactInfoDto();
        }
    }

}
