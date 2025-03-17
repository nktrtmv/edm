using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Converters.Queries.GetDocumentsToSign.DocumentsToSign;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Services.GetDocumentsToSign.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Queries.GetDocumentsToSign;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Queries.GetDocumentsToSign.DocumentsToSign;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Converters.Queries.GetDocumentsToSign;

internal static class GetDocumentsToSignSigningWorkflowActionQueryResponseExternalConverter
{
    internal static GetDocumentsToSignSigningWorkflowActionQueryResponseExternal FromDto(GetDocumentsToSignSigningWorkflowQueryResponse response)
    {
        SigningWorkflowDocumentToSignExternal[] documentsToSign = response.DocumentsToSign.Select(SigningWorkflowDocumentToSignExternalConverter.FromDto).ToArray();

        var result = new GetDocumentsToSignSigningWorkflowActionQueryResponseExternal(documentsToSign);

        return result;
    }
}
