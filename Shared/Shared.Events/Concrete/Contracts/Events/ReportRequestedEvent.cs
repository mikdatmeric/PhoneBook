using Shared.Events.Abstract;

namespace Shared.Events.Concrete.Contracts.Events
{
    public class ReportRequestedEvent : IIntegrationEvent
    {
        public Guid ReportId { get; set; }
        public DateTime RequestedAt { get; set; }
    }
}
