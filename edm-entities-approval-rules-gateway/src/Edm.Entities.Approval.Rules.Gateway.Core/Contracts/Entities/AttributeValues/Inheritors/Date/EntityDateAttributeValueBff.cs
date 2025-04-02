namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Date;

public sealed class EntityDateAttributeValueBff : EntityAttributeValueBff
{
    public required DateOnly Value { get; init; }
}
