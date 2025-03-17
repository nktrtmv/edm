namespace Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Types;

public enum SigningActionType
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
