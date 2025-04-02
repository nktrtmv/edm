using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetCurrentExecutors.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Executors.Extractors.ApprovalWorkflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Entities;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetCurrentExecutors;

[UsedImplicitly]
internal sealed class GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalHandler
    : IRequestHandler<GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternal, GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse>
{
    public GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalHandler(ApprovalWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private ApprovalWorkflowsFacade Workflows { get; }

    public async Task<GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse> Handle(
        GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternal request,
        CancellationToken cancellationToken)
    {
        Id<ApprovalWorkflowEntity> entityId = IdConverterFrom<ApprovalWorkflowEntity>.From(request.EntityId);

        ApprovalWorkflow[] workflows = await Workflows.GetByEntityId(entityId, request.IsProcessingRequired, cancellationToken);

        Id<Employee>[] response = ApprovalWorkflowsExecutorsExtractor.ExtractCurrent(workflows);

        GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse result =
            GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponseConverter.FromDomain(response);

        return result;
    }
}
