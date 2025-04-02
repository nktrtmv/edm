using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetWorkflows.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows;

internal static class GetWorkflowsSigningWorkflowDetailsQueryResponseExternalConverter
{
    internal static GetWorkflowsSigningWorkflowDetailsQueryResponseExternal FromDto(GetSigningWorkflowDocumentWorkflowsQueryResponse response)
    {
        SigningWorkflowExternal[] workflows = response.Workflows.Select(SigningWorkflowExternalConverter.FromDto).ToArray();

        var result = new GetWorkflowsSigningWorkflowDetailsQueryResponseExternal(workflows);

        return result;
    }
}
