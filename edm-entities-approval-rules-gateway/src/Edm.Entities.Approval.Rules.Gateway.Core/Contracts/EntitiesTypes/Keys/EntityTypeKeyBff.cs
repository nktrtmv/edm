namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;

public sealed class EntityTypeKeyBff
{
    public required string DomainId { get; init; }
    public required string EntityTypeId { get; init; }
    public required DateTime EntityTypeUpdatedDate { get; init; }
}
