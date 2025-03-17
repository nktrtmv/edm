using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts.Rules;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts;

public sealed class GetAllApprovalRulesQueryResponseBff
{
    public required GetAllApprovalRulesQueryResponseApprovalRuleBff[] Rules { get; init; }
}
