namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Complete.CompletionReason;

public enum ReductionWorkflowActionCompletionReasonExternal
{
    None = 0,
    Approved = 1,
    ApprovedWithRemark = 2,
    ReturnedToRework = 3,
    Rejected = 4
}
