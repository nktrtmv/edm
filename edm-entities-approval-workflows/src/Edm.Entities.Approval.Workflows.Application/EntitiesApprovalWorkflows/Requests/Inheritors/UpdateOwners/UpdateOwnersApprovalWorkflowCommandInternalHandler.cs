using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.UpdateOwners.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Owners.Updaters;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.UpdateOwners;

[UsedImplicitly]
internal sealed class UpdateOwnersApprovalWorkflowCommandInternalHandler(
    ApprovalWorkflowsFacade workflows,
    ILogger<UpdateOwnersApprovalWorkflowCommandInternalHandler> logger)
    : IRequestHandler<UpdateOwnersEntitiesApprovalWorkflowsRequestInternal>
{
    public async Task Handle(UpdateOwnersEntitiesApprovalWorkflowsRequestInternal request, CancellationToken cancellationToken)
    {
        Id<ApprovalWorkflow> workflowId = IdConverterFrom<ApprovalWorkflow>.From(request.WorkflowId);

        var workflow = await Get(workflowId, request, cancellationToken);

        if (workflow is null)
        {
            return;
        }

        Id<Employee> ownerId = IdConverterFrom<Employee>.From(request.OwnerId);

        ApprovalWorkflowOwnersUpdater.Update(workflow, ownerId);

        await workflows.Upsert(workflow, cancellationToken);
    }

    private async Task<ApprovalWorkflow?> Get(
        Id<ApprovalWorkflow> workflowId,
        UpdateOwnersEntitiesApprovalWorkflowsRequestInternal request,
        CancellationToken cancellationToken)
    {
        var workflow = await workflows.Get(workflowId, false, cancellationToken);

        if (workflow is not null)
        {
            return workflow;
        }

        logger.LogError(
            """
            Approval workflow is not found.
            WorkflowId: {WorkflowId}
            Request: {@Request}
            """,
            workflowId,
            request);

        return null;
    }
}
