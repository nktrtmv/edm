using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts.Context;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.AddParticipant.Contracts;

public sealed record AddParticipantEntitiesApprovalWorkflowsActionsCommandInternal(
    ApprovalWorkflowActionContextInternal Context,
    Id<EmployeeInternal> NewParticipantId,
    Id<ApprovalWorkflowGroupInternal>? GroupId,
    string? GroupName,
    string Comment,
    bool DryRunAndLock)
    : ActionsCommandInternal(Context, DryRunAndLock);
