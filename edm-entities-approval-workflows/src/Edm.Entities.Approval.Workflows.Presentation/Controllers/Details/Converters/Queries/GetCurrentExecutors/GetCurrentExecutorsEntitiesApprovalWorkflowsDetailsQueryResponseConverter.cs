using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetCurrentExecutors.Contracts;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetCurrentExecutors;

internal static class GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryResponseConverter
{
    internal static GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryResponse FromInternal(
        GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse response)
    {
        string[] executors = response.Executors.Select(IdConverterTo.ToString).ToArray();

        var result = new GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryResponse
        {
            Executors = { executors }
        };

        return result;
    }
}
