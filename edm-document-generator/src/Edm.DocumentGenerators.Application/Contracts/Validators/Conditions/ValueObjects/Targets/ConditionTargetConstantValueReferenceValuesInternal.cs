namespace Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects.Targets;

public sealed class ConditionTargetConstantValueReferenceInternal(string[] values) : IConditionTargetInternal
{
    public string[] Values { get; init; } = values;
}
