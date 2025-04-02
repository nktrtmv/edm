using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Factories;

public static class SigningDocumentFactory
{
    public static SigningDocument CreateFrom(Id<Attachment> documentId)
    {
        Id<Edo>? edoId = null;

        Id<Attachment>? signatureId = null;

        SigningDocumentState state = SigningDocumentStateFactory.CreateFrom(SigningDocumentStatus.PendingSelfSigning);

        SigningDocument result = CreateFromDb(edoId, documentId, signatureId, state);

        return result;
    }

    public static SigningDocument CreateFrom(KeyValuePair<Id<Attachment>, Id<Attachment>> documentWithSignature)
    {
        Id<Edo>? edoId = null;

        SigningDocumentState state = SigningDocumentStateFactory.CreateFrom(SigningDocumentStatus.SignedBySelf);

        SigningDocument result = CreateFromDb(
            edoId,
            documentWithSignature.Key,
            documentWithSignature.Value,
            state);

        return result;
    }

    public static SigningDocument CreateFrom(Id<Attachment> documentId, Id<Edo>? edoId, SigningDocumentState state)
    {
        Id<Attachment>? signatureId = null;

        SigningDocument result = CreateFromDb(edoId, documentId, signatureId, state);

        return result;
    }

    public static SigningDocument CreateFrom(SigningDocument document, Id<Attachment>? signatureId)
    {
        SigningDocument result = CreateFromDb(document.EdoId, document.DocumentId, signatureId, document.State);

        return result;
    }

    public static SigningDocument CreateFromDb(
        Id<Edo>? edoId,
        Id<Attachment> documentId,
        Id<Attachment>? signatureId,
        SigningDocumentState state)
    {
        var result = new SigningDocument(edoId, documentId, signatureId, state);

        return result;
    }
}
