using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendWorkflowCompleted.Converters.Statuses;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendWorkflowCompleted;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted.Statuses;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendWorkflowCompleted.Converters;

internal static class WorkflowCompletedEntitiesSigningWorkflowResultInternalConverter
{
    internal static WorkflowCompletedEntitiesSigningWorkflowResultInternal FromDomain(
        SigningWorkflow workflow,
        SendWorkflowCompletedSigningApplicationEvent applicationEvent)
    {
        WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal status =
            WorkflowCompletedEntitiesSigningWorkflowResultStatusInternalConverter.FromDomain(applicationEvent.LastFinishedStageStatus);

        var result = new WorkflowCompletedEntitiesSigningWorkflowResultInternal(
            workflow.DomainId,
            workflow.EntityId,
            workflow.Id,
            status,
            applicationEvent.CurrentUserId);

        return result;
    }
}
