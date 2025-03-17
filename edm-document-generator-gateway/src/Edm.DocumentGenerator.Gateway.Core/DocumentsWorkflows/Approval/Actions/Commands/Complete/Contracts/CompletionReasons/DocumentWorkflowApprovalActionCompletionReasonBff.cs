namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Complete.Contracts.CompletionReasons;

public enum DocumentWorkflowApprovalActionCompletionReasonBff
{
    None = 0,
    Approved = 1,
    ApprovedWithRemark = 2,
    ReturnedToRework = 3,
    Rejected = 4
}
