using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetDocumentsToSign.Contracts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetDocumentsToSign.Contracts.DocumentsToSign;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetDocumentsToSign;

internal static class GetSigningDocumentsToSignQueryResponseConverter
{
    internal static GetSigningDocumentsToSignQueryResponse FromInternal(GetSigningDocumentsToSignQueryInternalResponse response)
    {
        SigningDocumentToSignDto[] documents = response.Documents.Select(SigningDocumentToSignDtoConverter.FromInternal).ToArray();

        var result = new GetSigningDocumentsToSignQueryResponse
        {
            Documents = { documents }
        };

        return result;
    }
}
