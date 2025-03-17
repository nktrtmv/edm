using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Documents.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Documents;

public sealed class SigningEdxDocumentExternal
{
    public SigningEdxDocumentExternal(Id<AttachmentExternal> documentId, Id<AttachmentExternal>? signatureId)
    {
        DocumentId = documentId;
        SignatureId = signatureId;
    }

    public Id<AttachmentExternal> DocumentId { get; }
    public Id<AttachmentExternal>? SignatureId { get; }
}
