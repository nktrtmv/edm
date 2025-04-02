using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects.Targets;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects;

public sealed class ConditionDataBff
{
    public ConditionDataBff(
        string conditionId,
        string[] linkedDocumentAttributeIds,
        ConditionTargetBff? target,
        string[] supportedDocumentStatusIds)
    {
        ConditionId = conditionId;
        LinkedDocumentAttributeIds = linkedDocumentAttributeIds;
        Target = target;
        SupportedDocumentStatusIds = supportedDocumentStatusIds;
    }

    public string ConditionId { get; }

    public string[] LinkedDocumentAttributeIds { get; }

    public ConditionTargetBff? Target { get; }

    public string[] SupportedDocumentStatusIds { get; }
}
