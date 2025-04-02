using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Signing.Statuses;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Signing;

public sealed class SigningWorkflowDocumentUpdate
{
    public SigningWorkflowDocumentUpdate(Id<User> currentUserId, Id<DocumentSigningWorkflow> workflowId, DocumentSigningStatus status)
    {
        CurrentUserId = currentUserId;
        WorkflowId = workflowId;
        Status = status;
    }

    public Id<User> CurrentUserId { get; }
    public Id<DocumentSigningWorkflow> WorkflowId { get; }
    public DocumentSigningStatus Status { get; }
}
