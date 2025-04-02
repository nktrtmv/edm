using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts.Context;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.TakeInWork.Contracts;

public sealed record TakeInWorkEntitiesApprovalWorkflowsActionsCommandInternal(ApprovalWorkflowActionContextInternal Context, bool DryRunAndLock)
    : ActionsCommandInternal(Context, DryRunAndLock);
