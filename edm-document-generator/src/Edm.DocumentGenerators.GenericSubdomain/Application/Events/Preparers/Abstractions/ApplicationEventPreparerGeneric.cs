using Edm.DocumentGenerators.GenericSubdomain.Domain.ApplicationEvents;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Events.Preparers.Abstractions;

public abstract class ApplicationEventPreparerGeneric<THost, TApplicationEvent>(ILogger logger) : IApplicationEventPreparer<THost>
    where TApplicationEvent : ApplicationEvent
{
    public async Task Prepare(ApplicationEvent applicationEvent, THost host, CancellationToken cancellationToken)
    {
        if (applicationEvent is not TApplicationEvent e)
        {
            return;
        }

        try
        {
            logger.LogDebug(
                """
                PREPARE APPLICATION EVENT START: 🔵 {@Event}
                Host: {Host}
                """,
                applicationEvent,
                host);

            await OnPrepare(e, host, cancellationToken);

            logger.LogDebug(
                """
                PREPARE APPLICATION EVENT END: {@Event}
                Host: {Host}
                """,
                applicationEvent,
                host);
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                """
                PREPARE APPLICATION EVENT ERROR: ❌ {@Event} {@Message}
                Host: {Host}
                """,
                applicationEvent,
                ex.Message,
                host);

            throw;
        }
    }

    protected abstract Task OnPrepare(TApplicationEvent applicationEvent, THost host, CancellationToken cancellationToken);
}
