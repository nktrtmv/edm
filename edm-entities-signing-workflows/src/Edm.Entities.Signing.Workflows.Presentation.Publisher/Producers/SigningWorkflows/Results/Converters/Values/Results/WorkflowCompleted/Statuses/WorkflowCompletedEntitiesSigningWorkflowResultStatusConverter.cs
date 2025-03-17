using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted.Statuses;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Results.Converters.Values.Results.WorkflowCompleted.Statuses;

internal static class WorkflowCompletedEntitiesSigningWorkflowResultStatusConverter
{
    internal static WorkflowCompletedEntitiesSigningWorkflowResultStatus FromInternal(WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal status)
    {
        WorkflowCompletedEntitiesSigningWorkflowResultStatus result = status switch
        {
            WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal.Signed => WorkflowCompletedEntitiesSigningWorkflowResultStatus.Signed,
            WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal.Cancelled => WorkflowCompletedEntitiesSigningWorkflowResultStatus.Cancelled,
            WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal.ReturnedToRework => WorkflowCompletedEntitiesSigningWorkflowResultStatus.ReturnedToRework,
            WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal.Withdrawn => WorkflowCompletedEntitiesSigningWorkflowResultStatus.Withdrawn,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
