using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted.Statuses;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendWorkflowCompleted.Converters.Statuses;

internal static class WorkflowCompletedEntitiesSigningWorkflowResultStatusInternalConverter
{
    internal static WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal FromDomain(SigningStageStatus lastFinishedStageStatus)
    {
        WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal result = lastFinishedStageStatus switch
        {
            SigningStageStatus.Signed => WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal.Signed,
            SigningStageStatus.Cancelled => WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal.Cancelled,
            SigningStageStatus.ReturnedToRework => WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal.ReturnedToRework,
            SigningStageStatus.Withdrawn => WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal.Withdrawn,
            _ => throw new ArgumentTypeOutOfRangeException(lastFinishedStageStatus)
        };

        return result;
    }
}
