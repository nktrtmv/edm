using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors.Contexts;
using Edm.DocumentGenerators.GenericSubdomain.Domain.ApplicationEvents;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors.Abstractions;

public abstract class ApplicationEventProcessorGeneric<THost, TApplicationEvent>(ILogger logger) : IApplicationEventProcessor<THost>
    where TApplicationEvent : ApplicationEvent
{
    protected ILogger Logger { get; } = logger;

    public async Task Process(ApplicationEventProcessContext<THost> context, CancellationToken cancellationToken)
    {
        if (context.ApplicationEvent is not TApplicationEvent e)
        {
            return;
        }

        try
        {
            Logger.LogDebug($"PROCESS APPLICATION EVENT START: 🔷 {context.ApplicationEvent:l}\nHost: {context.Host:l}");

            await OnProcess(e, context.Host, cancellationToken);

            Logger.LogDebug($"PROCESS APPLICATION EVENT END: {context.ApplicationEvent:l}\nHost: {context.Host:l}");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, $"PROCESS APPLICATION EVENT ERROR: ❌ {context.ApplicationEvent:l}\nHost: {context.Host:l}\n{ex.Message}");

            throw;
        }
    }

    protected abstract Task OnProcess(TApplicationEvent applicationEvent, THost host, CancellationToken cancellationToken);
}
