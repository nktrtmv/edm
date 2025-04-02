using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Commands.Sign.Contracts.Contracts.DocumentsWithSignature;

internal static class SigningDocumentWithSignatureInternalConverter
{
    internal static KeyValuePair<Id<Attachment>, Id<Attachment>> ToDomain(SigningDocumentWithSignatureInternal document)
    {
        Id<Attachment> documentId = IdConverterFrom<Attachment>.From(document.DocumentId);

        Id<Attachment> signatureId = IdConverterFrom<Attachment>.From(document.SignatureId);

        var result = new KeyValuePair<Id<Attachment>, Id<Attachment>>(documentId, signatureId);

        return result;
    }
}
