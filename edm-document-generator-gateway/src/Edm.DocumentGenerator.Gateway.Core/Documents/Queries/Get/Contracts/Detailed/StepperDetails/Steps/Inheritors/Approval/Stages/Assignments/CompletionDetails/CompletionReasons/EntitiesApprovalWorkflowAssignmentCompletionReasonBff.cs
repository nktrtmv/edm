namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    CompletionReasons;

public enum EntitiesApprovalWorkflowAssignmentCompletionReasonBff
{
    None = 0,
    Approved = 1,
    ApprovedWithRemark = 2,
    ReturnedToRework = 3,
    Rejected = 4,
    Delegated = 5,
    CompletedAutomatically = 6
}
