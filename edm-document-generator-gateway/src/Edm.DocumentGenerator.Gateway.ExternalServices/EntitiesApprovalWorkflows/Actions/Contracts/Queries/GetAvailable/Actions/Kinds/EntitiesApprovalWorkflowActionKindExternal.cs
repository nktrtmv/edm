namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Queries.GetAvailable.Actions.Kinds;

public enum EntitiesApprovalWorkflowActionKindExternal
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
