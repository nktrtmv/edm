using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Targets.Generics.SingleValue;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Enrichers;

public sealed class EntityAttributeValueBffEnricherTarget : SingleValueEnricherTargetGeneric<int, EntityTypeAttributeDto>
{
    internal EntityAttributeValueBffEnricherTarget(EntityAttributeValueBff target)
    {
        Target = target;
    }

    private EntityAttributeValueBff Target { get; }

    protected override int GetKey()
    {
        return Target.Id;
    }

    protected override void EnrichTarget(EntityTypeAttributeDto value)
    {
        Target.DisplayName = value.Data.DisplayName;
    }
}
