using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.Definition;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ForDocumentAttributesValues.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ForDocumentAttributesValues;

public sealed class ConditionCompare : ConditionBase
{
    private readonly Func<int, bool> _comparisonFunction;

    static ConditionCompare()
    {
        TypeRequirements = new ConditionAttributesRequirements(
            new[]
            {
                new SupportedAttributeType(typeof(DateDocumentAttributeValue), SupportedAttributeType.IsArrayEnum.Any),
                new SupportedAttributeType(typeof(NumberDocumentAttributeValue), SupportedAttributeType.IsArrayEnum.Any),
                new SupportedAttributeType(typeof(BooleanDocumentAttributeValue), SupportedAttributeType.IsArrayEnum.Any)
            },
            true,
            ConditionSupportedTargetType.AttributeValue & ConditionSupportedTargetType.Constant);
    }

    public ConditionCompare(ConditionData data, ConditionCompareType compareType) : base(data)
    {
        _comparisonFunction = compareType switch
        {
            ConditionCompareType.Great => p => p > 0,
            ConditionCompareType.GreatOrEqual => p => p >= 0,
            ConditionCompareType.Equal => p => p == 0,
            ConditionCompareType.LessOrEqual => p => p <= 0,
            ConditionCompareType.Less => p => p < 0,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };
        CompareType = compareType;
    }

    private static ConditionAttributesRequirements TypeRequirements { get; }
    public ConditionCompareType CompareType { get; }
    protected override ConditionAttributesRequirements Requirements => TypeRequirements;

    protected override ConditionResult OnCheck(DocumentAttributeValue[] attributesValues)
    {
        if (Data.Target is null)
        {
            throw new ArgumentNullException($"{nameof(Data.Target)} can't be null.");
        }

        ConditionResult? result = null;

        if (Data.Target.TypeIs<Number<NumberDocumentAttributeValue>>(attributesValues))
        {
            result = CheckGeneric<Number<NumberDocumentAttributeValue>>(attributesValues);
        }

        if (Data.Target.TypeIs<UtcDateTime<DateDocumentAttributeValue>>(attributesValues))
        {
            result = CheckGeneric<UtcDateTime<DateDocumentAttributeValue>>(attributesValues);
        }

        if (Data.Target.TypeIs<bool>(attributesValues))
        {
            result = CheckGeneric<bool>(attributesValues);
        }

        if (result is null)
        {
            throw new ArgumentException("Type not supported.");
        }

        return result;
    }

    private ConditionResult CheckGeneric<T>(DocumentAttributeValue[] documentAttributesValues) where T : IComparable<T>
    {
        var target = Data.Target!.GetValue<T>(documentAttributesValues);
        DocumentAttributeValueGeneric<T>[] linkedDocumentAttributesValues = GetLinkedAttributesValuesGeneric<T>(documentAttributesValues);

        Id<DocumentAttribute>[] failedAttributes = linkedDocumentAttributesValues
            .Where(p => !CheckDocumentAttributeValue(p, target))
            .Select(p => p.Id)
            .ToArray();

        return ConditionResult.Create(Id, failedAttributes);
    }

    private bool CheckDocumentAttributeValue<T>(DocumentAttributeValueGeneric<T> attributeValue, T target) where T : IComparable<T>
    {
        return attributeValue.Values.All(p => _comparisonFunction(p.CompareTo(target)));
    }
}
