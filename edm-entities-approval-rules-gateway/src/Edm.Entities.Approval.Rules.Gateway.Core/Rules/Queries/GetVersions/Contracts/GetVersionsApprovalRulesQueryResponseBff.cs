using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetVersions.Contracts.Rules;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetVersions.Contracts;

public sealed class GetVersionsApprovalRulesQueryResponseBff
{
    public required GetVersionsApprovalRulesQueryResponseApprovalRuleBff[] Rules { get; init; }
}
