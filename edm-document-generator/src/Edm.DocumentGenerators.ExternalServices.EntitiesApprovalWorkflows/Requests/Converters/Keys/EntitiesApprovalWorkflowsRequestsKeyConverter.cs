using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Keys;

internal static class EntitiesApprovalWorkflowsRequestsKeyConverter
{
    internal static EntitiesApprovalWorkflowsRequestsKey FromExternal(EntitiesApprovalWorkflowsRequestExternal request)
    {
        var key = IdConverterTo.ToString(request.Document.Id);

        var result = new EntitiesApprovalWorkflowsRequestsKey
        {
            Key = key
        };

        return result;
    }
}
