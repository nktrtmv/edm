using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts;

public sealed class CreateWorkflowEntitiesApprovalWorkflowsRequestInternal : EntitiesApprovalWorkflowsRequestInternal
{
    public CreateWorkflowEntitiesApprovalWorkflowsRequestInternal(
        Id<ApprovalWorkflowInternal> workflowId,
        ApprovalRouteInternal approvalRoute,
        ApprovalParametersInternal parameters,
        Id<EmployeeInternal> currentUserId) : base(workflowId)
    {
        ApprovalRoute = approvalRoute;
        Parameters = parameters;
        CurrentUserId = currentUserId;
    }

    public ApprovalRouteInternal ApprovalRoute { get; }
    public ApprovalParametersInternal Parameters { get; }
    public Id<EmployeeInternal> CurrentUserId { get; }
}
