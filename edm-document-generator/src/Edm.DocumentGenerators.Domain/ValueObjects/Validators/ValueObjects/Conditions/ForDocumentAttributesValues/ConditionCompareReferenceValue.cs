using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.Definition;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ForDocumentAttributesValues.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects.Targets;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ForDocumentAttributesValues;

public sealed class ConditionCompareReferenceValue : ConditionBase
{
    private readonly Func<IEnumerable<string>, IEnumerable<string>, bool> _comparisonFunction;

    static ConditionCompareReferenceValue()
    {
        TypeRequirements = new ConditionAttributesRequirements([], false, ConditionSupportedTargetType.AttributeValue);
    }

    public ConditionCompareReferenceValue(ConditionData data, ConditionCompareReferenceValueType compareType) : base(data)
    {
        _comparisonFunction = compareType switch
        {
            ConditionCompareReferenceValueType.OneOf => (attributeValues, targetValues) => attributeValues.Any(targetValues.Contains),
            ConditionCompareReferenceValueType.NoOneOf => (attributeValues, targetValues) => attributeValues.All(p => !targetValues.Contains(p)),
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };
        CompareType = compareType;
    }

    public ConditionCompareReferenceValueType CompareType { get; }

    private static ConditionAttributesRequirements TypeRequirements { get; }

    protected override ConditionAttributesRequirements Requirements => TypeRequirements;

    protected override ConditionResult OnCheck(DocumentAttributeValue[] attributesValues)
    {
        ArgumentNullException.ThrowIfNull(Data.Target);

        if (Data.Target is not ConditionTargetConstantValueGeneric<string[]> targetAttribute)
        {
            throw new UnsupportedTypeArgumentException<ConditionTargetConstantValueGeneric<string[]>>(Data.Target);
        }

        DocumentAttributeValue[] linkedAttributeValues = GetLinkedAttributesValues(attributesValues);

        Id<DocumentAttribute>[] failedAttributes = linkedAttributeValues
            .Where(p => !CheckAttributeValue(p, targetAttribute.Value))
            .Select(p => p.Id)
            .ToArray();

        return ConditionResult.Create(Id, failedAttributes);
    }

    private bool CheckAttributeValue(DocumentAttributeValue attributeValue, string[] targetValues)
    {
        if (attributeValue is not ReferenceDocumentAttributeValue referenceAttributeValue)
        {
            return true;
        }

        bool result = _comparisonFunction(referenceAttributeValue.Values, targetValues);

        return result;
    }
}
