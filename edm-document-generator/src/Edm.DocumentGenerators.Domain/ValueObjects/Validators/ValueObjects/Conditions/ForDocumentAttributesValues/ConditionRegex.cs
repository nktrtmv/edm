using System.Text.RegularExpressions;

using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.Definition;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ForDocumentAttributesValues;

public sealed class ConditionRegex : ConditionBase
{
    static ConditionRegex()
    {
        TypeRequirements = new ConditionAttributesRequirements(
            new[]
            {
                new SupportedAttributeType(typeof(StringDocumentAttributeValue), SupportedAttributeType.IsArrayEnum.Any),
                new SupportedAttributeType(typeof(AttachmentDocumentAttributeValue), SupportedAttributeType.IsArrayEnum.Any)
            },
            true,
            ConditionSupportedTargetType.Constant);
    }

    public ConditionRegex(ConditionData data) : base(data)
    {
    }

    private static ConditionAttributesRequirements TypeRequirements { get; }

    protected override ConditionAttributesRequirements Requirements => TypeRequirements;

    protected override ConditionResult OnCheck(DocumentAttributeValue[] attributesValues)
    {
        string expression = Data.Target?.GetValue<string>(attributesValues) ??
            throw new ArgumentNullException($"{nameof(Data.Target)} can't be null.");

        var regex = new Regex(expression);

        DocumentAttributeValueGeneric<string>[] linkedDocumentAttributesValues = GetLinkedAttributesValuesGeneric<string>(attributesValues);

        Id<DocumentAttribute>[] notValid = linkedDocumentAttributesValues
            .Where(p => !CheckSingleAttribute(p, regex))
            .Select(p => p.Id)
            .ToArray();

        return ConditionResult.Create(Id, notValid);
    }

    private static bool CheckSingleAttribute(DocumentAttributeValueGeneric<string> stringAttributeValue, Regex regex)
    {
        return stringAttributeValue.Values.All(regex.IsMatch);
    }
}
