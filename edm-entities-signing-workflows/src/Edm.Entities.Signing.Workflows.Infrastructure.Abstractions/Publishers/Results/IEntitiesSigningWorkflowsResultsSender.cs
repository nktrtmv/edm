using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results;

public interface IEntitiesSigningWorkflowsResultsSender
{
    Task Send(EntitiesSigningWorkflowsResultInternal result, CancellationToken cancellationToken);
}
