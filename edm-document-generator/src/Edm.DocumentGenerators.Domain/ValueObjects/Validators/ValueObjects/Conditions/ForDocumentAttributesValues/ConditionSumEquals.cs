using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.Definition;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ForDocumentAttributesValues;

public sealed class ConditionSumEquals : ConditionBase
{
    static ConditionSumEquals()
    {
        TypeRequirements = new ConditionAttributesRequirements(
            new[]
            {
                new SupportedAttributeType(typeof(NumberDocumentAttributeValue), SupportedAttributeType.IsArrayEnum.Any)
            },
            true,
            ConditionSupportedTargetType.AttributeValue & ConditionSupportedTargetType.Constant);
    }

    public ConditionSumEquals(ConditionData data) : base(data)
    {
    }

    private static ConditionAttributesRequirements TypeRequirements { get; }

    protected override ConditionAttributesRequirements Requirements => TypeRequirements;

    protected override ConditionResult OnCheck(DocumentAttributeValue[] attributesValues)
    {
        Number<NumberDocumentAttributeValue> targetSum = Data.Target?.GetValue<Number<NumberDocumentAttributeValue>>(attributesValues) ??
            throw new ArgumentNullException($"{nameof(Data.Target)} can't be null.");

        DocumentAttributeValueGeneric<Number<NumberDocumentAttributeValue>>[] linkedAttributesValues =
            GetLinkedAttributesValuesGeneric<Number<NumberDocumentAttributeValue>>(attributesValues);

        long sum = linkedAttributesValues.Sum(p => p.Values.Select(NumberConverterTo.ToLong).Sum());

        bool isValid = sum == NumberConverterTo.ToLong(targetSum);

        ConditionResult result = !isValid ? ConditionResult.Create(Id, Data.LinkedDocumentAttributeIds) : ConditionResult.Succeed(Id);

        return result;
    }
}
