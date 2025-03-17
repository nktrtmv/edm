using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects.Targets;

public interface IConditionTarget
{
    T GetValue<T>(DocumentAttributeValue[] attributesValues);

    bool TypeIs<T>(DocumentAttributeValue[] attributesValues);
}
