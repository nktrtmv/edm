using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow;

[UsedImplicitly]
internal sealed class CreateWorkflowEntitiesApprovalWorkflowsRequestInternalHandler(
    ApprovalWorkflowsFacade workflowsFacade,
    ApprovalWorkflowStageActivator stageActivator,
    ILogger<CreateWorkflowEntitiesApprovalWorkflowsRequestInternalHandler> logger)
    : IRequestHandler<CreateWorkflowEntitiesApprovalWorkflowsRequestInternal>
{
    public async Task Handle(CreateWorkflowEntitiesApprovalWorkflowsRequestInternal request, CancellationToken cancellationToken)
    {
        Id<ApprovalWorkflow> workflowId = IdConverterFrom<ApprovalWorkflow>.From(request.WorkflowId);

        var workflow = await workflowsFacade.Get(workflowId, false, cancellationToken);

        if (workflow is not null)
        {
            return;
        }

        var parameters = ApprovalWorkflowParametersInternalConverter.ToDomain(request);

        ApprovalWorkflowStage[] stages = ApprovalRouteInternalConverter.ToDomain(request);

        Id<Employee> ownerId = IdConverterFrom<Employee>.From(request.Parameters.OwnerId);

        Id<Employee>? documentAuthorId = NullableConverter.Convert(request.Parameters.DocumentAuthorId, IdConverterFrom<Employee>.From);

        workflow = ApprovalWorkflowFactory.CreateNew(workflowId, parameters, stages, ownerId, documentAuthorId);

        try
        {
            await stageActivator.TryActivate(workflow, cancellationToken);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed Activate Stage.\nWorkflow: {Workflow}", workflow);

            throw;
        }

        await workflowsFacade.Upsert(workflow, cancellationToken);
    }
}
