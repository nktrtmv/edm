namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes.Abstractions.Data;

public sealed class EntityTypeAttributeDataBff
{
    public required int Id { get; init; }
    public string DisplayName { get; set; } = string.Empty;
}
