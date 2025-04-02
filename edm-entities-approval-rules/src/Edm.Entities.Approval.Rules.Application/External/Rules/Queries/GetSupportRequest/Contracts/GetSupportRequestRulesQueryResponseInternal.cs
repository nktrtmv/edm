using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.GetSupportRequest.Contracts.Rules;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.GetSupportRequest.Contracts;

public sealed record GetSupportRequestRulesQueryResponseInternal(GetSupportRequestRulesQueryResponseApprovalRuleInternal[] Rules);
