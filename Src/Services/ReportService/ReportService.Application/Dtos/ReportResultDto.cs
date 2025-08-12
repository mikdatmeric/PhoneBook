using PhoneBook.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Dtos
{
    public class ReportResultDto : IDto
    {
        public string Location { get; set; } = string.Empty;
        public int PersonCount { get; set; }
        public int PhoneCount { get; set; }
    }
}
