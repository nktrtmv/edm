namespace Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Kinds;

public enum ApprovalWorkflowActionKind
{
    None = 0,
    Approve = 1,
    ApproveWithRemark = 2,
    ReturnToRework = 3,
    Reject = 4,
    Delegate = 5,
    AddParticipant = 6,
    TakeInWork = 7
}
