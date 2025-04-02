using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Keys;

internal static class EntitiesSigningWorkflowsRequestsKeyConverter
{
    internal static EntitiesSigningWorkflowsRequestsKey FromExternal(EntitiesSigningWorkflowsRequestExternal request)
    {
        var key = IdConverterTo.ToString(request.Document.Id);

        var result = new EntitiesSigningWorkflowsRequestsKey
        {
            Key = key
        };

        return result;
    }
}
