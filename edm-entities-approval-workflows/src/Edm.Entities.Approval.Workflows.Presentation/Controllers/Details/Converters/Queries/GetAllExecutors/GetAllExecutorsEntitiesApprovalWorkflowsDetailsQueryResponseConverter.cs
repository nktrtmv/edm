using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetAllExecutors.Contracts;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetAllExecutors;

internal static class GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryResponseConverter
{
    internal static GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryResponse FromInternal(
        GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse response)
    {
        string[] executors = response.Executors.Select(IdConverterTo.ToString).ToArray();

        var result = new GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryResponse
        {
            Executors = { executors }
        };

        return result;
    }
}
