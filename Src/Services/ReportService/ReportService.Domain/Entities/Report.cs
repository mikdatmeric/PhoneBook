using PhoneBook.Core.Concrete;
using static ReportService.Domain.Enums.Enums;

namespace ReportService.Domain.Entities
{
    public class Report : BaseEntity
    {
        public Guid ReportCode { get; set; } = Guid.NewGuid(); // UUID
        public DateTime RequestedAt { get; set; }
        public ReportStatus Status { get; set; }
        public string? ResultJson { get; set; } // Rapor sonuç listesi JSON formatında
      
    }
}
