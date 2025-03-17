using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows;
using Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Results.WorkflowCompleted.Contracts.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Results.WorkflowCompleted.Contracts;

public sealed class WorkflowCompletedEntitiesSigningWorkflowsResultInternal : IRequest
{
    public WorkflowCompletedEntitiesSigningWorkflowsResultInternal(
        Id<DocumentInternal> documentId,
        Id<DocumentSigningWorkflowInternal> workflowId,
        DocumentSigningStatusInternal status,
        Id<UserInternal> currentUserId)
    {
        DocumentId = documentId;
        WorkflowId = workflowId;
        Status = status;
        CurrentUserId = currentUserId;
    }

    internal Id<DocumentInternal> DocumentId { get; }
    internal Id<DocumentSigningWorkflowInternal> WorkflowId { get; }
    internal DocumentSigningStatusInternal Status { get; }
    internal Id<UserInternal> CurrentUserId { get; }
}
