namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.
    CompletionReasons;

public enum EntitiesApprovalWorkflowAssignmentCompletionReasonExternal
{
    None = 0,
    Approved = 1,
    ApprovedWithRemark = 2,
    ReturnedToRework = 3,
    Rejected = 4,
    Delegated = 5,
    CompletedAutomatically = 6
}
