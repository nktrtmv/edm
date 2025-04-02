using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events;

public interface IEntitiesSigningWorkflowsEventsSender
{
    Task Send(EntitiesSigningWorkflowsEventInternal message, CancellationToken cancellationToken);
}
