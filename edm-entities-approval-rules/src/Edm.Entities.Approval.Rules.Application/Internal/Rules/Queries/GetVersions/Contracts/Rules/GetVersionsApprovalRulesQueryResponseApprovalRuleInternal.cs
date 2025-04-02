using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Briefs;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions.Contracts.Rules;

public sealed record GetVersionsApprovalRulesQueryResponseApprovalRuleInternal(
    ApprovalRuleKeyInternal ApprovalRuleKey,
    string DisplayName,
    int OriginalVersion,
    AuditBriefInternal<GetVersionsApprovalRulesQueryResponseApprovalRuleInternal> Audit,
    bool IsActive,
    bool IsReadonly,
    ConcurrencyToken<GetVersionsApprovalRulesQueryResponseApprovalRuleInternal> ConcurrencyToken);
