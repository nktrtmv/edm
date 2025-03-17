using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Queries.GetAvailable.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Queries.GetAvailable.Contracts.Kinds;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Queries.GetAvailable;

[UsedImplicitly]
public sealed class GetAvailableEntitiesApprovalWorkflowsActionsQueryInternalHandler(ApprovalWorkflowsFacade workflows)
    : IRequestHandler<GetAvailableEntitiesApprovalWorkflowsActionsQueryInternal, GetAvailableEntitiesApprovalWorkflowsActionsQueryInternalResponse>

{
    public async Task<GetAvailableEntitiesApprovalWorkflowsActionsQueryInternalResponse> Handle(
        GetAvailableEntitiesApprovalWorkflowsActionsQueryInternal query,
        CancellationToken cancellationToken)
    {
        var workflowId = IdConverterFrom<ApprovalWorkflow>.From(query.WorkflowId);

        var workflow = await workflows.GetRequired(workflowId, false, cancellationToken);

        var context =
            GetAvailableEntitiesApprovalWorkflowsActionsQueryInternalConverter.ToDomain(query, workflow);

        var actions = AvailableApprovalWorkflowActionsDetector.Detect(context);

        var actionsInternal =
            actions.Select(ApprovalWorkflowsActionKindInternalConverter.FromDomain).ToArray();

        var result = new GetAvailableEntitiesApprovalWorkflowsActionsQueryInternalResponse(actionsInternal);

        return result;
    }
}
