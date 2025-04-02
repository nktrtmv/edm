using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows;

internal static class GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryConverter
{
    internal static GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternal ToInternal(GetWorkflowsEntitiesApprovalWorkflowsDetailsQuery query)
    {
        Id<ApprovalWorkflowInternal>[] workflowsIds =
            query.WorkflowsIds.Select(IdConverterFrom<ApprovalWorkflowInternal>.FromString).ToArray();

        var result = new GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternal(workflowsIds);

        return result;
    }
}
