using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.Definition;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects.Targets;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ForDocumentAttributesValues;

public sealed class ConditionExistsWithReferencePrecondition : ConditionBase
{
    static ConditionExistsWithReferencePrecondition()
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
            ConditionSupportedTargetType.AttributeValue);
    }

    public ConditionExistsWithReferencePrecondition(ConditionData data, string preconditionReferenceId) : base(data)
    {
        PreconditionReferenceId = preconditionReferenceId;
    }

    private static ConditionAttributesRequirements TypeRequirements { get; }

    protected override ConditionAttributesRequirements Requirements => TypeRequirements;

    public string PreconditionReferenceId { get; }

    protected override ConditionResult OnCheck(DocumentAttributeValue[] attributesValues)
    {
        if (Data.Target is null)
        {
            throw new ArgumentNullException($"{nameof(Data.Target)} can't be null.");
        }

        if (Data.Target is not ConditionTargetDocumentAttribute targetAttribute)
        {
            throw new UnsupportedTypeArgumentException<ReferenceDocumentAttributeValue>(Data.Target);
        }

        DocumentAttributeValue attributeValue = attributesValues
            .Single(p => p.Attribute.Id == targetAttribute.DocumentAttributeId);

        if (attributeValue is not ReferenceDocumentAttributeValue referenceTargetAttributeValue)
        {
            throw new UnsupportedTypeArgumentException<ReferenceDocumentAttributeValue>(attributeValue);
        }

        string? targetValue = referenceTargetAttributeValue.Values.FirstOrDefault();

        if (PreconditionReferenceId != targetValue)
        {
            return ConditionResult.Succeed(Id);
        }

        DocumentAttributeValue[] linkedAttributesValues = GetLinkedAttributesValues(attributesValues);

        Id<DocumentAttribute>[] notValid = linkedAttributesValues
            .Where(p => !CheckAttributeValue(p))
            .Select(p => p.Id)
            .ToArray();

        return ConditionResult.Create(Id, notValid);
    }

    private static bool CheckAttributeValue(DocumentAttributeValue attributeValue)
    {
        return !ValueIsEmptyOrDefault(attributeValue);
    }
}
