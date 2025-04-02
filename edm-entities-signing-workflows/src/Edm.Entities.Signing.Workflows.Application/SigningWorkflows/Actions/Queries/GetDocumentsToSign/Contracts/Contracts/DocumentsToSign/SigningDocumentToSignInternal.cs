using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetDocumentsToSign.Contracts.Contracts.DocumentsToSign;

public sealed class SigningDocumentToSignInternal
{
    public SigningDocumentToSignInternal(Id<AttachmentInternal> documentId)
    {
        DocumentId = documentId;
    }

    public Id<AttachmentInternal> DocumentId { get; }
}
