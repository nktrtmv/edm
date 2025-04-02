namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects.Targets.ConditionTargetConstantValue;

public class ConditionTargetConstantValueGenericBff<T> : ConditionTargetBff
{
    public required T Value { get; init; }
}
