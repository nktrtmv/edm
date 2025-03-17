using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Entities;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetAllExecutors.Contracts;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetAllExecutors;

internal static class GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryConverter
{
    internal static GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternal ToInternal(GetAllExecutorsEntitiesApprovalWorkflowsDetailsQuery request)
    {
        Id<ApprovalEntityInternal> entityId = IdConverterFrom<ApprovalEntityInternal>.FromString(request.EntityId);

        var result = new GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternal(entityId, request.IsProcessingRequired);

        return result;
    }
}
