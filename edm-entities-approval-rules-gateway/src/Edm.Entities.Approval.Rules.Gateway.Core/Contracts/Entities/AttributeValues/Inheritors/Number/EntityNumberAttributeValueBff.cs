namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Number;

public sealed class EntityNumberAttributeValueBff : EntityAttributeValueBff
{
    public required long Value { get; init; }
}
