using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.Statuses;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Assignments.Statuses;

internal static class EntitiesApprovalWorkflowAssignmentStatusConverter
{
    internal static EntitiesApprovalWorkflowAssignmentStatusDto FromInternal(
        EntitiesApprovalWorkflowAssignmentStatusInternal status)
    {
        return status switch
        {
            EntitiesApprovalWorkflowAssignmentStatusInternal.NotStarted => EntitiesApprovalWorkflowAssignmentStatusDto.NotStarted,
            EntitiesApprovalWorkflowAssignmentStatusInternal.InProgress => EntitiesApprovalWorkflowAssignmentStatusDto.InProgress,
            EntitiesApprovalWorkflowAssignmentStatusInternal.Completed => EntitiesApprovalWorkflowAssignmentStatusDto.Completed,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
