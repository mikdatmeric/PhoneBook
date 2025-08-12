using static ReportService.Domain.Enums.Enums;

namespace ReportService.Application.Dtos
{
    public class ReportDetailDto
    {
        public int Id { get; set; }
        public Guid ReportCode { get; set; }
        public DateTime RequestedAt { get; set; }
        public ReportStatus Status { get; set; }
        public List<ReportResultDto> Data { get; set; }
    }
}
