using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetVersions.Contracts;

public sealed class GetVersionsApprovalRulesQueryBff
{
    public required EntityTypeKeyBff EntityTypeKey { get; init; }
}
