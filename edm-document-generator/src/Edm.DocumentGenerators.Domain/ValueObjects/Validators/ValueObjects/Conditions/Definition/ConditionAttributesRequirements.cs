namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.Definition;

public sealed class ConditionAttributesRequirements
{
    public ConditionAttributesRequirements(
        IReadOnlyCollection<SupportedAttributeType> supportedAttributeTypes,
        bool theSameTypes,
        ConditionSupportedTargetType supportedTargetTypes,
        bool needDocumentStatuses = false)
    {
        SupportedAttributeTypes = supportedAttributeTypes;
        TheSameTypes = theSameTypes;
        SupportedTargetTypes = supportedTargetTypes;
        NeedDocumentStatuses = needDocumentStatuses;
    }

    public IReadOnlyCollection<SupportedAttributeType> SupportedAttributeTypes { get; }
    public bool TheSameTypes { get; }
    public ConditionSupportedTargetType SupportedTargetTypes { get; }

    public bool NeedDocumentStatuses { get; }
}
