using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Preparers.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain.Domain.ApplicationEvents;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Events.Preparers;

public sealed class ApplicationEventsPreparer<T>
{
    public ApplicationEventsPreparer(IEnumerable<IApplicationEventPreparer<T>> preparers)
    {
        Preparers = preparers.ToArray();
    }

    private IApplicationEventPreparer<T>[] Preparers { get; }

    public async Task Prepare<TApplicationEvent>(IList<TApplicationEvent> applicationEvents, T host, CancellationToken cancellationToken)
        where TApplicationEvent : ApplicationEvent
    {
        if (applicationEvents.Count == 0)
        {
            return;
        }

        foreach (TApplicationEvent applicationEvent in applicationEvents)
        {
            await Prepare(applicationEvent, host, cancellationToken);
        }
    }

    private async Task Prepare(ApplicationEvent applicationEvent, T host, CancellationToken cancellationToken)
    {
        foreach (IApplicationEventPreparer<T> processor in Preparers)
        {
            await processor.Prepare(applicationEvent, host, cancellationToken);
        }
    }
}
