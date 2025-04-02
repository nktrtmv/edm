using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.Definition;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects.Targets;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ForDocumentAttributesValues;

public sealed class ConditionEmpty : ConditionBase
{
    static ConditionEmpty()
    {
        TypeRequirements = new ConditionAttributesRequirements(
            new[]
            {
                new SupportedAttributeType(typeof(StringDocumentAttributeValue), SupportedAttributeType.IsArrayEnum.Any),
                new SupportedAttributeType(typeof(AttachmentDocumentAttributeValue), SupportedAttributeType.IsArrayEnum.Any),
                new SupportedAttributeType(typeof(BooleanDocumentAttributeValue), SupportedAttributeType.IsArrayEnum.Any),
                new SupportedAttributeType(typeof(DateDocumentAttributeValue), SupportedAttributeType.IsArrayEnum.Any),
                new SupportedAttributeType(typeof(NumberDocumentAttributeValue), SupportedAttributeType.IsArrayEnum.Any),
                new SupportedAttributeType(typeof(TupleDocumentAttributeValue), SupportedAttributeType.IsArrayEnum.Any),
                new SupportedAttributeType(typeof(ReferenceDocumentAttributeValue), SupportedAttributeType.IsArrayEnum.Any)
            },
            false,
            ConditionSupportedTargetType.AttributeValue & ConditionSupportedTargetType.Constant);
    }

    public ConditionEmpty(ConditionData data) : base(data)
    {
    }

    private static ConditionAttributesRequirements TypeRequirements { get; }

    protected override ConditionAttributesRequirements Requirements => TypeRequirements;

    protected override ConditionResult OnCheck(DocumentAttributeValue[] attributesValues)
    {
        DocumentAttributeValue[] linkedAttributesValues = GetLinkedAttributesValues(attributesValues);

        if (Data.Target is ConditionTargetDocumentAttribute target)
        {
            bool targetIsNotEmpty = !ValueIsEmptyOrDefault(attributesValues.Single(p => p.Attribute.Id == target.DocumentAttributeId));

            if (targetIsNotEmpty)
            {
                return ConditionResult.Succeed(Id);
            }
        }

        Id<DocumentAttribute>[] notValid = linkedAttributesValues
            .Where(p => !CheckAttributeValue(p))
            .Select(p => p.Id)
            .ToArray();

        return ConditionResult.Create(Id, notValid, Data.LinkedDocumentAttributeIds);
    }

    private static bool CheckAttributeValue(DocumentAttributeValue attributeValue)
    {
        return ValueIsEmptyOrDefault(attributeValue);
    }
}
