using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Approval.Workflows.Presentation.Publisher.Results.Converters.Keys;

internal static class EntitiesApprovalWorkflowsResultsKeyConverter
{
    internal static EntitiesApprovalWorkflowsResultsKey FromDomain(EntitiesApprovalWorkflowsResultInternal request)
    {
        var result = new EntitiesApprovalWorkflowsResultsKey
        {
            Key = request.EntityId
        };

        return result;
    }
}
