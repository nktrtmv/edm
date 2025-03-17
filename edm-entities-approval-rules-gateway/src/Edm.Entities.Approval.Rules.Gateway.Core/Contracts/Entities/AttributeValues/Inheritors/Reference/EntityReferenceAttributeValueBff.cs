using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Reference.Values;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Reference;

public sealed class EntityReferenceAttributeValueBff : EntityAttributeValueBff
{
    public EntityReferenceAttributeValueValueBff[] Value { get; set; } = Array.Empty<EntityReferenceAttributeValueValueBff>();
}
