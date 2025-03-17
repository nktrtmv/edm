using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results;

public interface IEntitiesApprovalWorkflowsResultsSender
{
    Task Send(EntitiesApprovalWorkflowsResultInternal request, CancellationToken cancellationToken);
}
