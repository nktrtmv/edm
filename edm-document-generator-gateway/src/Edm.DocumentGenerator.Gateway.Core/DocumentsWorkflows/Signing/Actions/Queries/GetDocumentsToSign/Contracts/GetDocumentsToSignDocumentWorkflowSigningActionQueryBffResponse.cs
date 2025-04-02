using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Queries.GetDocumentsToSign.Contracts.DocumentsToSign;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Queries.GetDocumentsToSign.Contracts;

public sealed class GetDocumentsToSignDocumentWorkflowSigningActionQueryBffResponse
{
    public required DocumentWorkflowSigningDocumentToSignBff[] Documents { get; init; }
}
