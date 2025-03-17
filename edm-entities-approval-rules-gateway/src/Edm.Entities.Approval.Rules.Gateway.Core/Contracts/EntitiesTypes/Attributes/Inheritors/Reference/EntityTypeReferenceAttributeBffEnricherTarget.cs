using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Targets.Generics.SingleValue;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Inheritors.Reference;

internal sealed class EntityTypeReferenceAttributeBffEnricherTarget : SingleValueEnricherTargetGeneric<int, EntityTypeAttributeDto>
{
    internal EntityTypeReferenceAttributeBffEnricherTarget(EntityTypeReferenceAttributeBff target)
    {
        Target = target;
    }

    private EntityTypeReferenceAttributeBff Target { get; }

    protected override int GetKey()
    {
        return Target.Data.Id;
    }

    protected override void EnrichTarget(EntityTypeAttributeDto value)
    {
        Target.ReferenceTypeId = value.AsReference.ReferenceTypeId;
        Target.Data.DisplayName = value.Data.DisplayName;
    }
}
