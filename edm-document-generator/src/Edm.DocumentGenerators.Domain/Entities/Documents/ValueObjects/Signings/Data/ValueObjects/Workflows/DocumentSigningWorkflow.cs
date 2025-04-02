using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;

public sealed class DocumentSigningWorkflow
{
    internal DocumentSigningWorkflow(
        Id<DocumentSigningWorkflow> id,
        DocumentSigningWorkflowStatus status,
        bool isSelfSigned)
    {
        Id = id;
        Status = status;
        IsSelfSigned = isSelfSigned;
    }

    public Id<DocumentSigningWorkflow> Id { get; }
    public DocumentSigningWorkflowStatus Status { get; private set; }
    public bool IsSelfSigned { get; private set; }

    public void SetStatus(DocumentSigningWorkflowStatus status)
    {
        Status = status;
    }

    internal void SetIsSelfSigned()
    {
        IsSelfSigned = true;
    }
}
