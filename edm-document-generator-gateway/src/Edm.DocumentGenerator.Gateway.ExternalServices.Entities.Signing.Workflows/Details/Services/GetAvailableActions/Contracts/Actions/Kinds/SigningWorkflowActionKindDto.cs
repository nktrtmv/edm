namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetAvailableActions.Contracts.Actions.Kinds;

public enum SigningWorkflowActionKindDto
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
