using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows;
using Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Results.WorkflowCompleted.Contracts;
using Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Results.WorkflowCompleted.Contracts.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Results.Converters.WorkflowCompleted.Contracts.Statuses;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Results.Converters.WorkflowCompleted;

internal static class WorkflowCompletedEntitiesSigningWorkflowResultConverter
{
    internal static WorkflowCompletedEntitiesSigningWorkflowsResultInternal ToInternal(WorkflowCompletedEntitiesSigningWorkflowResult message)
    {
        Id<DocumentInternal>? documentId =
            IdConverterFrom<DocumentInternal>.FromString(message.EntityId);

        Id<DocumentSigningWorkflowInternal> workflowId =
            IdConverterFrom<DocumentSigningWorkflowInternal>.FromString(message.WorkflowId);

        DocumentSigningStatusInternal status =
            WorkflowCompletedEntitiesSigningWorkflowResultStatusConverter.ToInternal(message.Status);

        Id<UserInternal> currentUserId = string.IsNullOrWhiteSpace(message.CurrentUserId)
            ? Id<UserInternal>.Empty01
            : IdConverterFrom<UserInternal>.FromString(message.CurrentUserId);

        var result = new WorkflowCompletedEntitiesSigningWorkflowsResultInternal(documentId, workflowId, status, currentUserId);

        return result;
    }
}
