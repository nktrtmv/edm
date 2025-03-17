using Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Results.WorkflowCompleted.Contracts.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Results.Converters.WorkflowCompleted.Contracts.Statuses;

internal static class WorkflowCompletedEntitiesSigningWorkflowResultStatusConverter
{
    internal static DocumentSigningStatusInternal ToInternal(WorkflowCompletedEntitiesSigningWorkflowResultStatus status)
    {
        DocumentSigningStatusInternal result = status switch
        {
            WorkflowCompletedEntitiesSigningWorkflowResultStatus.Signed => DocumentSigningStatusInternal.Signed,
            WorkflowCompletedEntitiesSigningWorkflowResultStatus.Cancelled => DocumentSigningStatusInternal.Cancelled,
            WorkflowCompletedEntitiesSigningWorkflowResultStatus.ReturnedToRework => DocumentSigningStatusInternal.ReturnedToRework,
            WorkflowCompletedEntitiesSigningWorkflowResultStatus.Withdrawn => DocumentSigningStatusInternal.ToPreparation,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
