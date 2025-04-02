using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.UpdateDocumentAuthor.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.UpdateDocumentAuthor;

[UsedImplicitly]
internal sealed class UpdateDocumentAuthorApprovalWorkflowCommandInternalHandler(
    ApprovalWorkflowsFacade workflows,
    ILogger<UpdateDocumentAuthorApprovalWorkflowCommandInternalHandler> logger) : IRequestHandler<UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestInternal>
{
    public async Task Handle(UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestInternal request, CancellationToken cancellationToken)
    {
        var workflowId = IdConverterFrom<ApprovalWorkflow>.From(request.WorkflowId);

        var workflow = await Get(workflowId, request, cancellationToken);

        if (workflow is null)
        {
            return;
        }

        Id<Employee> documentAuthorId = IdConverterFrom<Employee>.From(request.DocumentAuthorId);

        workflow.State.SetDocumentAuthorId(documentAuthorId);

        await workflows.Upsert(workflow, cancellationToken);
    }

    private async Task<ApprovalWorkflow?> Get(
        Id<ApprovalWorkflow> workflowId,
        UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestInternal request,
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
