using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Sign.Contracts.Contracts.DocumentsWithSignature;

public sealed class SigningDocumentWithSignatureInternal
{
    public SigningDocumentWithSignatureInternal(Id<AttachmentInternal> documentId, Id<AttachmentInternal> signatureId)
    {
        DocumentId = documentId;
        SignatureId = signatureId;
    }

    public Id<AttachmentInternal> DocumentId { get; }
    public Id<AttachmentInternal> SignatureId { get; }
}
