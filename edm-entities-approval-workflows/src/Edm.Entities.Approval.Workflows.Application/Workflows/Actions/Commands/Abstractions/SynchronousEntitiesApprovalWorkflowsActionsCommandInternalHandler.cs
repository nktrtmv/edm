using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;

using JetBrains.Annotations;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Abstractions;

[UsedImplicitly]
public abstract class SynchronousEntitiesApprovalWorkflowsActionsCommandInternalHandler<T>(ApprovalWorkflowsFacade workflows)
    : EntitiesApprovalWorkflowsActionsCommandInternalHandler<T>(workflows)
    where T : ActionsCommandInternal
{
    protected override Task Process(T command, ApprovalWorkflowActionContext context, CancellationToken cancellationToken)
    {
        Process(command, context);

        return Task.CompletedTask;
    }

    protected abstract void Process(T command, ApprovalWorkflowActionContext context);
}
