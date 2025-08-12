using PhoneBook.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ContactService.Domain.Enums.Enums;

namespace ContactService.Application.Dtos.ContactInfo
{
    public class ContactInfoDto : IDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public ContactInfoType Type { get; set; } 
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
