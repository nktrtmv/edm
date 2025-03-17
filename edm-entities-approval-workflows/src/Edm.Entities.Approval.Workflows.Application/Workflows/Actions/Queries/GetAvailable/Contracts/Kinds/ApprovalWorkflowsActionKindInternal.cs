namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Queries.GetAvailable.Contracts.Kinds;

public enum ApprovalWorkflowsActionKindInternal
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
