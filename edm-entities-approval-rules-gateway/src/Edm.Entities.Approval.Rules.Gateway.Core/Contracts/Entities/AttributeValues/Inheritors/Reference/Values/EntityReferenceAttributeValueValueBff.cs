namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues.Inheritors.Reference.Values;

public sealed class EntityReferenceAttributeValueValueBff
{
    public required string Id { get; init; }
    public string DisplayValue { get; set; } = string.Empty;
    public string DisplaySubValue { get; set; } = string.Empty;
}
