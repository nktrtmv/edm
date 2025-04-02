namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetAvailableActions.Actions.Kinds;

public enum SigningWorkflowActionKindExternal
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
