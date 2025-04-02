using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors.Contexts;

namespace Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors.Abstractions;

public interface IApplicationEventProcessor<T>
{
    Task Process(ApplicationEventProcessContext<T> context, CancellationToken cancellationToken);
}
