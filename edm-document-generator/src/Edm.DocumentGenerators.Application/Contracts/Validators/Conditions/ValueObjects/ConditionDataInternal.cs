using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects.Targets;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects;

public sealed class ConditionDataInternal
{
    public ConditionDataInternal(
        Id<ConditionBaseInternal> conditionId,
        Id<DocumentAttributeInternal>[] linkedDocumentAttributeIds,
        IConditionTargetInternal? target,
        Id<DocumentStatusInternal>[] supportedDocumentStatusIds)
    {
        ConditionId = conditionId;
        LinkedDocumentAttributeIds = linkedDocumentAttributeIds;
        Target = target;
        SupportedDocumentStatusIds = supportedDocumentStatusIds;
    }

    public Id<ConditionBaseInternal> ConditionId { get; }
    public Id<DocumentAttributeInternal>[] LinkedDocumentAttributeIds { get; }
    public IConditionTargetInternal? Target { get; }
    public Id<DocumentStatusInternal>[] SupportedDocumentStatusIds { get; }
}
