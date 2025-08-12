using Shared.Events.Abstract;

namespace Shared.Events.Concrete.Contracts.Events
{
    public class ReportRequestedEvent : IIntegrationEvent
    {
        public Guid ReportCode { get; set; }
        public DateTime RequestedAt { get; set; }
    }
}
