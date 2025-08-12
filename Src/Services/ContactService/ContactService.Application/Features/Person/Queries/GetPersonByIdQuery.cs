using ContactService.Application.Dtos.Person;
using MediatR;
using PhoneBook.Core.Concrete.Utulities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Application.Features.Person.Queries
{
    public class GetPersonByIdQuery : IRequest<Result<PersonDetailDto>>
    {
        public GetPersonByIdRequestDto Dto { get; set; }

        public GetPersonByIdQuery(GetPersonByIdRequestDto requestDto)
        {
            Dto = requestDto ?? throw new ArgumentNullException(nameof(requestDto), "Request DTO cannot be null");
        }
    }
}
