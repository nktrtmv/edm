using Edm.DocumentGenerators.GenericSubdomain.Domain.ApplicationEvents;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Events.Preparers.Abstractions;

public interface IApplicationEventPreparer<in T>
{
    Task Prepare(ApplicationEvent applicationEvent, T host, CancellationToken cancellationToken);
}
