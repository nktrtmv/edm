using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetDocumentsToSign.Contracts.Contracts.DocumentsToSign;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetDocumentsToSign.Contracts;

public sealed class GetSigningDocumentsToSignQueryInternalResponse
{
    internal GetSigningDocumentsToSignQueryInternalResponse(SigningDocumentToSignInternal[] documents)
    {
        Documents = documents;
    }

    public SigningDocumentToSignInternal[] Documents { get; }
}
