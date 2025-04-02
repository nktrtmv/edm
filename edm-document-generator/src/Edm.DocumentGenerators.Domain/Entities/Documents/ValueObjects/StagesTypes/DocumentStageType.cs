namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StagesTypes;

public enum DocumentStageType
{
    None = 0,
    Draft = 1,
    Backlog = 2,
    ApprovalPreparation = 3,
    Approval = 4,
    SigningPreparation = 5,
    Signing = 6,
    InEffect = 7,
    Cancelled = 8
}
