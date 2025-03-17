using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Events.SelfSigned.Contracts;

public sealed class SelfSignedEntitiesSigningWorkflowsEventInternal : IRequest
{
    public SelfSignedEntitiesSigningWorkflowsEventInternal(
        Id<DocumentInternal> documentId,
        Id<DocumentSigningWorkflowInternal> workflowId)
    {
        DocumentId = documentId;
        WorkflowId = workflowId;
    }

    internal Id<DocumentInternal> DocumentId { get; }
    internal Id<DocumentSigningWorkflowInternal> WorkflowId { get; }
}
