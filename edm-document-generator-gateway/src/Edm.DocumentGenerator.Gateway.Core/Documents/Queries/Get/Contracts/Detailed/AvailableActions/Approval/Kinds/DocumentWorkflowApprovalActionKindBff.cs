namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Approval.Kinds;

public enum DocumentWorkflowApprovalActionKindBff
{
    None = 0,
    Approve = 1,
    ApproveWithRemark = 2,
    ReturnToRework = 3,
    Reject = 4,
    Delegate = 5,
    TakeInWork = 6,
    AddParticipant = 7
}
