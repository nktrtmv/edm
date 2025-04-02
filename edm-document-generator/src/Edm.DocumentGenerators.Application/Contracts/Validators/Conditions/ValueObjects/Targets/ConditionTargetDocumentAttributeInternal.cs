using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects.Targets;

public sealed class ConditionTargetDocumentAttributeInternal : IConditionTargetInternal
{
    public ConditionTargetDocumentAttributeInternal(Id<DocumentAttributeInternal> documentAttributeId)
    {
        DocumentAttributeId = documentAttributeId;
    }

    public Id<DocumentAttributeInternal> DocumentAttributeId { get; init; }
}
