using PhoneBook.Core.Abstractions;

namespace ReportService.Application.Dtos
{
    public class CompleteReportDto : IDto
    {
        public Guid ReportCode { get; set; }
        public List<ReportResultDto>? ReportResults { get; set; }
    }
}
