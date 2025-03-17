using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;

public sealed class SigningDocument
{
    internal SigningDocument(
        Id<Edo>? edoId,
        Id<Attachment> documentId,
        Id<Attachment>? signatureId,
        SigningDocumentState state)
    {
        EdoId = edoId;
        DocumentId = documentId;
        SignatureId = signatureId;
        State = state;
    }

    public Id<Edo>? EdoId { get; }
    public Id<Attachment> DocumentId { get; }
    public Id<Attachment>? SignatureId { get; }
    public SigningDocumentState State { get; }
}
