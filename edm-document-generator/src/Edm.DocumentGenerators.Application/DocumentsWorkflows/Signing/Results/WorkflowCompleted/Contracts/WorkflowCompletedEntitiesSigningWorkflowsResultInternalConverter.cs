using Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Results.WorkflowCompleted.Contracts.Statuses;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Signing;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Signing.Statuses;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Results.WorkflowCompleted.Contracts;

internal static class WorkflowCompletedEntitiesSigningWorkflowsResultInternalConverter
{
    internal static SigningWorkflowDocumentUpdate ToDomain(WorkflowCompletedEntitiesSigningWorkflowsResultInternal command, Id<User> currentUserId)
    {
        Id<DocumentSigningWorkflow> workflowId = IdConverterFrom<DocumentSigningWorkflow>.From(command.WorkflowId);

        DocumentSigningStatus status = DocumentSigningStatusInternalConverter.ToDomain(command.Status);

        var result = new SigningWorkflowDocumentUpdate(currentUserId, workflowId, status);

        return result;
    }
}
