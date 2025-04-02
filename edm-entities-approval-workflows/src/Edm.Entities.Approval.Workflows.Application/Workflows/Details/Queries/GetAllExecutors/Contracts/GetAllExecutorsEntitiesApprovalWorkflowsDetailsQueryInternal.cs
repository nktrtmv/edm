using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Entities;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetAllExecutors.Contracts;

[UsedImplicitly]
public sealed class GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternal : IRequest<GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse>
{
    public GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternal(Id<ApprovalEntityInternal> entityId, bool isProcessingRequired)
    {
        EntityId = entityId;
        IsProcessingRequired = isProcessingRequired;
    }

    internal Id<ApprovalEntityInternal> EntityId { get; }
    internal bool IsProcessingRequired { get; }
}
