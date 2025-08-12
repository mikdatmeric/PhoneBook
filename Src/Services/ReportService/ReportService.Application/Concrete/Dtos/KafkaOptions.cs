namespace ReportService.Application.Concrete.Dtos
{
    public class KafkaOptions
    {
        public string BootstrapServers { get; set; } = "localhost:9092";
        public string? ReportRequestedTopic { get; set; }
    }
}
