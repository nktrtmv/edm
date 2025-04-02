using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts.Rules.Types;

public sealed class EntityTypeSlimBff
{
    public required EntityTypeKeyBff Key { get; init; }
    public required string DisplayName { get; init; }
    public required bool IsActive { get; init; }
}
