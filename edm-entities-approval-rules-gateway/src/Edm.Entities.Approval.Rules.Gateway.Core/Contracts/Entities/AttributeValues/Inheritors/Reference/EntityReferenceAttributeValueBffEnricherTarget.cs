using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Reference.Values;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Enrichers.Sources.Keys;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Values;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Targets.Generics.SingleValue;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Reference;

public sealed class EntityReferenceAttributeValueBffEnricherTarget
    : SingleValueEnricherTargetGeneric<ApprovalReferenceEnricherKey, ApprovalReferenceValueExternal[]>
{
    internal EntityReferenceAttributeValueBffEnricherTarget(
        ApprovalReferenceEnricherKey key,
        EntityReferenceAttributeValueBff target)
    {
        Key = key;
        Target = target;
    }

    private ApprovalReferenceEnricherKey Key { get; }
    private EntityReferenceAttributeValueBff Target { get; }

    protected override ApprovalReferenceEnricherKey GetKey()
    {
        return Key;
    }

    protected override void EnrichTarget(ApprovalReferenceValueExternal[] values)
    {
        EntityReferenceAttributeValueValueBff[] value =
            values.Select(EntityReferenceAttributeValueValueBffConverter.FromExternal).ToArray();

        Target.Value = value;
    }
}
