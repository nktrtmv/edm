using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects.Targets;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects;

public sealed class ConditionData
{
    public ConditionData(
        Id<ICondition> conditionId,
        Id<DocumentAttribute>[] linkedDocumentAttributeIds,
        IConditionTarget? target,
        Id<DocumentStatus>[] supportedDocumentStatusIds)
    {
        ConditionId = conditionId;
        LinkedDocumentAttributeIds = linkedDocumentAttributeIds;
        Target = target;
        SupportedDocumentStatusIds = supportedDocumentStatusIds;
    }

    public Id<ICondition> ConditionId { get; }

    public Id<DocumentAttribute>[] LinkedDocumentAttributeIds { get; }

    public IConditionTarget? Target { get; }

    public Id<DocumentStatus>[] SupportedDocumentStatusIds { get; private set; }

    public void SetSupportedDocumentStatusIds(Id<DocumentStatus>[] supportedDocumentStatusIds) // ONLY FOR MIGRATION (VERSION_1 –> VERSION_2)
    {
        SupportedDocumentStatusIds = supportedDocumentStatusIds;
    }
}
