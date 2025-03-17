using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects.Targets;

public sealed class ConditionTargetConstantValueGeneric<T> : ConditionTargetConstantValue
{
    public ConditionTargetConstantValueGeneric(T value)
    {
        Value = value;
    }

    public T Value { get; init; }

    public override T1 GetValue<T1>(DocumentAttributeValue[] attributesValues)
    {
        if (Value is T1 castedResult)
        {
            return castedResult;
        }

        throw new InvalidCastException();
    }

    public override bool TypeIs<T1>(DocumentAttributeValue[] attributesValues)
    {
        return Value is T1;
    }
}
