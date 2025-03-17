using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts.Context;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.Delegate.Contracts;

public sealed record DelegateEntitiesApprovalWorkflowsActionsCommandInternal(
    ApprovalWorkflowActionContextInternal context,
    Id<EmployeeInternal> DelegateFromUserId,
    Id<EmployeeInternal> DelegateToUserId,
    string Comment,
    bool dryRunAndLock)
    : ActionsCommandInternal(context, dryRunAndLock);
