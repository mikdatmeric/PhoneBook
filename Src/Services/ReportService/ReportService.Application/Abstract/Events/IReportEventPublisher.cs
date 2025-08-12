using Shared.Events.Concrete.Contracts.Events;

namespace ReportService.Application.Abstract.Events
{
    public interface IReportEventPublisher
    {
        Task PublishReportRequestedAsync(ReportRequestedEvent reportRequestedEvent, CancellationToken ct = default);
    }
}
