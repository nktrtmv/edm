using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Application.Workflows.Tech.Queries.GetWorkflowsByEntity.Contracts;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Entities;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Tech.Queries.GetWorkflowsByEntity;

[UsedImplicitly]
internal sealed class GetWorkflowsByEntityTechQueryHandler(ApprovalWorkflowsFacade approvalWorkflowsFacade): IRequestHandler<GetWorkflowsByEntityTechQuery, GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflow[]>
{
    public async Task<GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflow[]> Handle(GetWorkflowsByEntityTechQuery request, CancellationToken cancellationToken)
    {
        Id<ApprovalWorkflowEntity> entityId = IdConverterFrom<ApprovalWorkflowEntity>.FromString(request.EntityId);

        ApprovalWorkflow[] workflows = await approvalWorkflowsFacade.GetByEntityId(entityId, false, cancellationToken);

        GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflow[] result =
            workflows.Select(GetEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflowConverter.FromDomain).ToArray();

        return result;
    }
}
