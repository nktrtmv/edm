namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Boolean;

public sealed class EntityBooleanAttributeValueBff : EntityAttributeValueBff
{
    public required bool Value { get; init; }
}
