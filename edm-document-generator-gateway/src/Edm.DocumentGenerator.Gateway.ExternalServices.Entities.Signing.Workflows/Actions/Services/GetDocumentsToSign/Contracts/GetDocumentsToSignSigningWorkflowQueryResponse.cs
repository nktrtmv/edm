using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Services.GetDocumentsToSign.Contracts.DocumentsToSign;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Services.GetDocumentsToSign.Contracts;

internal sealed class GetDocumentsToSignSigningWorkflowQueryResponse
{
    internal required SigningWorkflowDocumentToSignDto[] DocumentsToSign { get; init; }
}
