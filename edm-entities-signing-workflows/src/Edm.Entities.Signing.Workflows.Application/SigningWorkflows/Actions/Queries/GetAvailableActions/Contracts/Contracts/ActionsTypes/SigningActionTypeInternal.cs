namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetAvailableActions.Contracts.Contracts.ActionsTypes;

public enum SigningActionTypeInternal
{
    None = 0,
    Cancel = 1,
    PutIntoEffect = 2,
    ReturnToRework = 3,
    SendToContractor = 4,
    Sign = 5,
    WithdrawByContractor = 6,
    WithdrawBySelf = 7
}
