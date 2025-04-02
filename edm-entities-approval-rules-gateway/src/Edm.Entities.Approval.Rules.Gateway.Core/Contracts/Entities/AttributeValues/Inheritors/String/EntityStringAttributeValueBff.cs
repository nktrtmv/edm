namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.String;

public sealed class EntityStringAttributeValueBff : EntityAttributeValueBff
{
    public required string Value { get; init; }
}
