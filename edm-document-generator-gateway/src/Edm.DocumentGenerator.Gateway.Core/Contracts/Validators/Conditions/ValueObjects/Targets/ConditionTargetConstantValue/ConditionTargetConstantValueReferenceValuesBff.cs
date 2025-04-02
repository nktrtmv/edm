namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects.Targets.ConditionTargetConstantValue;

public sealed class ConditionTargetConstantValueReferenceBff : ConditionTargetBff
{
    public required string[] Values { get; init; }
}
