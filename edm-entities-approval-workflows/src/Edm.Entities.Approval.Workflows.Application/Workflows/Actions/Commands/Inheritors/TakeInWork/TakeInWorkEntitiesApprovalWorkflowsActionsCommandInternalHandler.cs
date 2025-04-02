using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Abstractions;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.TakeInWork.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.TakeInWork;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;

using JetBrains.Annotations;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.TakeInWork;

[UsedImplicitly]
public sealed class TakeInWorkEntitiesApprovalWorkflowsActionsCommandInternalHandler(ApprovalWorkflowsFacade workflows)
    : SynchronousEntitiesApprovalWorkflowsActionsCommandInternalHandler<TakeInWorkEntitiesApprovalWorkflowsActionsCommandInternal>(workflows)
{
    protected override void Process(TakeInWorkEntitiesApprovalWorkflowsActionsCommandInternal command, ApprovalWorkflowActionContext context)
    {
        TakeInWorkApprovalWorkflowsActionsCommandProcessor.TakeInWork(context);
    }
}
