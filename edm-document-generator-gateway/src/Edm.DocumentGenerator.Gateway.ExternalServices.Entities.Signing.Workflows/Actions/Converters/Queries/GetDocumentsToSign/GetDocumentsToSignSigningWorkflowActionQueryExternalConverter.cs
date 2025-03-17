using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Services.GetDocumentsToSign.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Queries.GetDocumentsToSign;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Converters.Queries.GetDocumentsToSign;

internal static class GetDocumentsToSignSigningWorkflowActionQueryExternalConverter
{
    internal static GetDocumentsToSignSigningWorkflowActionQuery ToDto(GetDocumentsToSignSigningWorkflowActionQueryExternal query)
    {
        var result = new GetDocumentsToSignSigningWorkflowActionQuery
        {
            WorkflowId = query.WorkflowId,
            CurrentUserId = query.CurrentUserId,
            IsCurrentUserAdmin = query.IsCurrentUserAdmin
        };

        return result;
    }
}
