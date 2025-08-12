using ContactService.Application.Dtos.ContactInfo;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;

namespace ContactService.Application.Features.ContactInfo.Commands
{
    public class CreateContactInfoCommand : IRequest<Result<int>>
    {
        public List<CreateContactInfoDto> ContactInfos { get; set; }
        public CreateContactInfoCommand(List<CreateContactInfoDto> createContactInfoRequestDtos)
        {
            ContactInfos = createContactInfoRequestDtos ?? new List<CreateContactInfoDto>();
        }
    }

}
