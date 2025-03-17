namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.Types;

public enum ConditionBffType
{
    None = 0,
    Compare = 1,
    Empty = 2,
    Exists = 3,
    ExistsAny = 4,
    ExistsWithReferencePrecondition = 5,
    Regex = 6,
    SumEquals = 7,
    CompareReference = 8
}
