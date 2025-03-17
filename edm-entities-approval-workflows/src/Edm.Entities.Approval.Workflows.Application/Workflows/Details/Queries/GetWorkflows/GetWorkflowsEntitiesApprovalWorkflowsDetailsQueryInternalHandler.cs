using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows;

[UsedImplicitly]
internal sealed class GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalHandler
    : IRequestHandler<GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternal, GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponse>
{
    public GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalHandler(ApprovalWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private ApprovalWorkflowsFacade Workflows { get; }

    public async Task<GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponse> Handle(
        GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternal request,
        CancellationToken cancellationToken)
    {
        Id<ApprovalWorkflow>[] workflowsIds = request.WorkflowsIds.Select(IdConverterFrom<ApprovalWorkflow>.From).ToArray();

        ApprovalWorkflow[] workflow = await Workflows.GetByIds(workflowsIds, false, cancellationToken);

        GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponse result =
            GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseConverter.FromDomain(workflow);

        return result;
    }
}
