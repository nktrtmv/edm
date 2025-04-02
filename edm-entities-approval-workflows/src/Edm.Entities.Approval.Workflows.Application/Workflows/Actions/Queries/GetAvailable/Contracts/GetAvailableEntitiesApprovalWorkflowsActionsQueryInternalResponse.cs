using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Queries.GetAvailable.Contracts.Kinds;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Queries.GetAvailable.Contracts;

public sealed class GetAvailableEntitiesApprovalWorkflowsActionsQueryInternalResponse
{
    public GetAvailableEntitiesApprovalWorkflowsActionsQueryInternalResponse(ApprovalWorkflowsActionKindInternal[] actions)
    {
        Actions = actions;
    }

    public ApprovalWorkflowsActionKindInternal[] Actions { get; }
}
