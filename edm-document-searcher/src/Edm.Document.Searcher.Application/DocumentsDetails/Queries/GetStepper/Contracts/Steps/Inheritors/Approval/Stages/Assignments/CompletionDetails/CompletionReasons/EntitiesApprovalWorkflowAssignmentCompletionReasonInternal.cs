namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    CompletionReasons;

public enum EntitiesApprovalWorkflowAssignmentCompletionReasonInternal
{
    None = 0,
    Approved = 1,
    ApprovedWithRemark = 2,
    ReturnedToRework = 3,
    Rejected = 4,
    Delegated = 5,
    CompletedAutomatically = 6
}
