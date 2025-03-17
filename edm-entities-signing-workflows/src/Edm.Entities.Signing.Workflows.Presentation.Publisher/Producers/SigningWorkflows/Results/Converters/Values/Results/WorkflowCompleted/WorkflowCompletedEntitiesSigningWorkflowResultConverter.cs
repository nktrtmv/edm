using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Results.Converters.Values.Results.WorkflowCompleted.Statuses;

namespace Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Results.Converters.Values.Results.WorkflowCompleted;

internal static class WorkflowCompletedEntitiesSigningWorkflowResultConverter
{
    internal static EntitiesSigningWorkflowsResultsValue FromInternal(
        string domainId,
        WorkflowCompletedEntitiesSigningWorkflowResultInternal message)
    {
        var entityId = IdConverterTo.ToString(message.EntityId);

        var workflowId = IdConverterTo.ToString(message.WorkflowId);

        WorkflowCompletedEntitiesSigningWorkflowResultStatus status =
            WorkflowCompletedEntitiesSigningWorkflowResultStatusConverter.FromInternal(message.Status);

        var currentUserId = IdConverterTo.ToString(message.CurrentUserId);

        var workflowCompleted = new WorkflowCompletedEntitiesSigningWorkflowResult
        {
            EntityId = entityId,
            WorkflowId = workflowId,
            Status = status,
            CurrentUserId = currentUserId
        };

        var result = new EntitiesSigningWorkflowsResultsValue
        {
            DomainId = domainId,
            WorkflowCompleted = workflowCompleted
        };

        return result;
    }
}
