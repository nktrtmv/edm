using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects.Targets;

public abstract class ConditionTargetConstantValue : IConditionTarget
{
    public abstract T GetValue<T>(DocumentAttributeValue[] attributesValues);

    public abstract bool TypeIs<T>(DocumentAttributeValue[] attributesValues);
}
