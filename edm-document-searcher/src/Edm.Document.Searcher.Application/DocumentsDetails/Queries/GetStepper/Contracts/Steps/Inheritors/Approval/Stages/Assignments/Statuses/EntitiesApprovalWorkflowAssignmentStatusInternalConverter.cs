using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.Statuses;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.
    Statuses;

internal static class EntitiesApprovalWorkflowAssignmentStatusInternalConverter
{
    internal static EntitiesApprovalWorkflowAssignmentStatusInternal FromExternal(EntitiesApprovalWorkflowAssignmentStatusExternal status)
    {
        EntitiesApprovalWorkflowAssignmentStatusInternal result = status switch
        {
            EntitiesApprovalWorkflowAssignmentStatusExternal.NotStarted => EntitiesApprovalWorkflowAssignmentStatusInternal.NotStarted,
            EntitiesApprovalWorkflowAssignmentStatusExternal.InProgress => EntitiesApprovalWorkflowAssignmentStatusInternal.InProgress,
            EntitiesApprovalWorkflowAssignmentStatusExternal.Completed => EntitiesApprovalWorkflowAssignmentStatusInternal.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
