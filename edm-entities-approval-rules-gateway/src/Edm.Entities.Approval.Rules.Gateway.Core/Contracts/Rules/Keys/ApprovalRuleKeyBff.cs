using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

public sealed class ApprovalRuleKeyBff
{
    public required EntityTypeKeyBff EntityTypeKey { get; init; }
    public required int Version { get; init; }
}
