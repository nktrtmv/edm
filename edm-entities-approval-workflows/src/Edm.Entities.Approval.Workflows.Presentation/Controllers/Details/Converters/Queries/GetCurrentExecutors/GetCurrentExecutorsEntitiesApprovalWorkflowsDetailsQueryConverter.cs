using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Entities;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetCurrentExecutors.Contracts;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetCurrentExecutors;

internal static class GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryConverter
{
    internal static GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternal ToInternal(GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQuery request)
    {
        Id<ApprovalEntityInternal> entityId = IdConverterFrom<ApprovalEntityInternal>.FromString(request.EntityId);

        var result = new GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternal(entityId, request.IsProcessingRequired);

        return result;
    }
}
