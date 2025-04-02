using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts.Rules;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts;

public sealed class SearchApprovalRulesQueryResponseBff
{
    public required SearchApprovalRulesQueryResponseApprovalRuleBff[] Rules { get; init; }
}
