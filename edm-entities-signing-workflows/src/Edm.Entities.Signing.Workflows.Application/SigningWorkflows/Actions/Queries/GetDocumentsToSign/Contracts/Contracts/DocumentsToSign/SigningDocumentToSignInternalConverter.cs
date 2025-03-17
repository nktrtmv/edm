using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetDocumentsToSign.Contracts.Contracts.DocumentsToSign;

internal static class SigningDocumentToSignInternalConverter
{
    internal static SigningDocumentToSignInternal FromDomain(SigningDocument document)
    {
        Id<AttachmentInternal> documentId = IdConverterFrom<AttachmentInternal>.From(document.DocumentId);

        var result = new SigningDocumentToSignInternal(documentId);

        return result;
    }
}
