using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Queries.GetAvailable.Contracts;

public sealed record GetAvailableEntitiesApprovalWorkflowsActionsQueryInternal(
    Id<ApprovalWorkflowInternal> WorkflowId,
    Id<EmployeeInternal> CurrentUserId,
    bool CurrentUserIsOwner,
    bool CurrentUserIsAdmin)
    : IRequest<GetAvailableEntitiesApprovalWorkflowsActionsQueryInternalResponse>;
