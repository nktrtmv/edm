using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetWorkflows.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows;

internal static class GetWorkflowsSigningWorkflowDetailsQueryExternalConverter
{
    internal static GetSigningWorkflowDocumentWorkflowsQuery ToDto(GetWorkflowsSigningWorkflowDetailsQueryExternal query)
    {
        string[] workflowsIds = query.Ids.ToArray();

        var result = new GetSigningWorkflowDocumentWorkflowsQuery
        {
            Ids = workflowsIds
        };

        return result;
    }
}
