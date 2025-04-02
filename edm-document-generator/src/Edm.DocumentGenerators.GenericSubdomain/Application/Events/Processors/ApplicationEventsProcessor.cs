using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors.Contexts;
using Edm.DocumentGenerators.GenericSubdomain.Domain.ApplicationEvents;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors;

public sealed class ApplicationEventsProcessor<T>(IEnumerable<IApplicationEventProcessor<T>> processors, ILogger<ApplicationEventsProcessor<T>> logger)
{
    private IApplicationEventProcessor<T>[] Processors { get; } = processors.ToArray();
    private ILogger<ApplicationEventsProcessor<T>> Logger { get; } = logger;

    public async Task<(bool, Exception?)> Process<TApplicationEvent>(IList<TApplicationEvent> applicationEvents, T host, CancellationToken cancellationToken)
        where TApplicationEvent : ApplicationEvent
    {
        try
        {
            Logger.LogDebug($"PROCESS APPLICATION EVENTS ({applicationEvents.Count}) START 🔵 Host: {host:l}");

            foreach (TApplicationEvent? applicationEvent in applicationEvents)
            {
                var context = new ApplicationEventProcessContext<T>(host, applicationEvent);

                await Process(context, cancellationToken);
            }

            Logger.LogDebug($"PROCESS APPLICATION EVENTS ({applicationEvents.Count}) END Host: {host:l}");

            return (true, null);
        }
        catch (Exception e)
        {
            return (false, e);
        }
    }

    private async Task Process(ApplicationEventProcessContext<T> context, CancellationToken cancellationToken)
    {
        foreach (IApplicationEventProcessor<T>? processor in Processors)
        {
            await processor.Process(context, cancellationToken);
        }
    }
}
