namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Signing.Kinds;

public enum DocumentWorkflowSigningActionKindBff
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
