namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Stages;

public enum DocumentStageTypeBff
{
    None = 0,
    Draft = 1,
    Backlog = 2,
    ApprovalPreparation = 3,
    Approval = 4,
    SigningPreparation = 5,
    Signing = 6,
    InEffect = 7,
    Cancelled = 8,
    SelfSigning = 9,
    ContractorSigning = 10
}
