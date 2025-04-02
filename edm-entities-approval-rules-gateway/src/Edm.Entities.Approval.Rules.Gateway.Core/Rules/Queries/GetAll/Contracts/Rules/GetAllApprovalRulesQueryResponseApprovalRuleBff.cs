using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts.Rules.Types;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts.Rules;

public sealed class GetAllApprovalRulesQueryResponseApprovalRuleBff
{
    public required EntityTypeSlimBff EntityType { get; init; }
}
