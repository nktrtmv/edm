using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetDocumentsToSign.Contracts.Contracts.DocumentsToSign;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetDocumentsToSign.Contracts.DocumentsToSign;

internal static class SigningDocumentToSignDtoConverter
{
    internal static SigningDocumentToSignDto FromInternal(SigningDocumentToSignInternal document)
    {
        var documentAttachmentId = IdConverterTo.ToString(document.DocumentId);

        var result = new SigningDocumentToSignDto
        {
            DocumentAttachmentId = documentAttachmentId
        };

        return result;
    }
}
