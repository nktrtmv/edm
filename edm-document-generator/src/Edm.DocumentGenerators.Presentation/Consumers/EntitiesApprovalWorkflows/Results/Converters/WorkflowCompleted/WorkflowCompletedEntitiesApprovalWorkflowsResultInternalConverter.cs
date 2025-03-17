using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData.Workflows;
using Edm.DocumentGenerators.Application.DocumentsWorkflows.Approval.Results.WorkflowCompleted.Contracts;
using Edm.DocumentGenerators.Application.DocumentsWorkflows.Approval.Results.WorkflowCompleted.Contracts.Statuses;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Consumers.EntitiesApprovalWorkflows.Results.Converters.WorkflowCompleted.Contracts.Statuses;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Consumers.EntitiesApprovalWorkflows.Results.Converters.WorkflowCompleted;

internal static class WorkflowCompletedEntitiesApprovalWorkflowsResultInternalConverter
{
    internal static WorkflowCompletedEntitiesApprovalWorkflowsResultInternal FromDto(
        WorkflowCompletedEntitiesApprovalWorkflowsResult message,
        string domainId)
    {
        Id<DocumentInternal>? documentId = IdConverterFrom<DocumentInternal>.FromString(message.EntityId);

        Id<DocumentApprovalWorkflowInternal> workflowId = IdConverterFrom<DocumentApprovalWorkflowInternal>.FromString(message.WorkflowId);

        DocumentApprovalStatusInternal status = DocumentApprovalStatusInternalConverter.FromDto(message.State.Status);

        Id<UserInternal> currentUserId = string.IsNullOrWhiteSpace(message.CompletedByUserId)
            ? Id<UserInternal>.Empty01
            : IdConverterFrom<UserInternal>.FromString(message.CompletedByUserId);

        var result = new WorkflowCompletedEntitiesApprovalWorkflowsResultInternal(
            DomainIdHelper.GetDomainIdOrSetDefault(domainId),
            documentId,
            workflowId,
            status,
            currentUserId);

        return result;
    }
}
