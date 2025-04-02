using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetAllExecutors.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Executors.Extractors.ApprovalWorkflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Entities;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetAllExecutors;

[UsedImplicitly]
internal sealed class GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalHandler
    : IRequestHandler<GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternal, GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse>
{
    public GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalHandler(ApprovalWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private ApprovalWorkflowsFacade Workflows { get; }

    public async Task<GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse> Handle(
        GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternal request,
        CancellationToken cancellationToken)
    {
        Id<ApprovalWorkflowEntity> entityId = IdConverterFrom<ApprovalWorkflowEntity>.From(request.EntityId);

        ApprovalWorkflow[] workflows = await Workflows.GetByEntityId(entityId, request.IsProcessingRequired, cancellationToken);

        Id<Employee>[] response = ApprovalWorkflowsExecutorsExtractor.ExtractAll(workflows);

        GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse result =
            GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponseConverter.FromDomain(response);

        return result;
    }
}
