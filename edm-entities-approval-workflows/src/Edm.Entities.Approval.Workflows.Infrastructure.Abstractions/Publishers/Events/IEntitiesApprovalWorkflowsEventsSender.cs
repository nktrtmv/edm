using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events;

public interface IEntitiesApprovalWorkflowsEventsSender
{
    Task Send(EntitiesApprovalWorkflowsEventInternal request, CancellationToken cancellationToken);
}
