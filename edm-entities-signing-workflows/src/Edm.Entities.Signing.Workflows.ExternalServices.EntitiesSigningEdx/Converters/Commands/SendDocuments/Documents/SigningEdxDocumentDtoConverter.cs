using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Documents;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Converters.Commands.SendDocuments.Documents;

internal static class SigningEdxDocumentDtoConverter
{
    internal static SigningEdxDocumentToSendDto FromExternal(SigningEdxDocumentExternal document)
    {
        var documentAttachmentId = IdConverterTo.ToString(document.DocumentId);

        var signatureAttachmentId = IdConverterTo.ToString(document.SignatureId!.Value);

        var result = new SigningEdxDocumentToSendDto
        {
            DocumentAttachmentId = documentAttachmentId,
            SignatureAttachmentId = signatureAttachmentId
        };

        return result;
    }
}
