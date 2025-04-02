namespace Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects.Targets;

public sealed class ConditionTargetConstantValueGenericInternal<T> : IConditionTargetInternal
{
    public ConditionTargetConstantValueGenericInternal(T value)
    {
        Value = value;
    }

    public T Value { get; init; }
}
