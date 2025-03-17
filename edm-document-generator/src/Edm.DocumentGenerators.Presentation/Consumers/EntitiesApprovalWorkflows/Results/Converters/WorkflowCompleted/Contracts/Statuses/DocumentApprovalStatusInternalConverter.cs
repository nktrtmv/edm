using Edm.DocumentGenerators.Application.DocumentsWorkflows.Approval.Results.WorkflowCompleted.Contracts.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Consumers.EntitiesApprovalWorkflows.Results.Converters.WorkflowCompleted.Contracts.Statuses;

internal static class DocumentApprovalStatusInternalConverter
{
    internal static DocumentApprovalStatusInternal FromDto(WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatus status)
    {
        DocumentApprovalStatusInternal result = status switch
        {
            WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatus.Approved => DocumentApprovalStatusInternal.Approved,
            WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatus.Rejected => DocumentApprovalStatusInternal.Cancelled,
            WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatus.ApprovedWithRemark => DocumentApprovalStatusInternal.ApprovedWithRemark,
            WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatus.ReturnedToRework => DocumentApprovalStatusInternal.ReturnedToRework,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
