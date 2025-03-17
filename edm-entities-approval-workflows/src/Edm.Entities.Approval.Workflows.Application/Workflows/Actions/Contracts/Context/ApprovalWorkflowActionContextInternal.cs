using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts.Context;

public sealed record ApprovalWorkflowActionContextInternal(
    Id<ApprovalWorkflowInternal> WorkflowId,
    Id<ApprovalWorkflowStageInternal> StageId,
    Id<EmployeeInternal> CurrentUserId,
    bool CurrentUserIsOwner,
    bool CurrentUserIsAdmin);
