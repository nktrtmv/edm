using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Keys;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Rules;

internal static class UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternalConverter
{
    internal static UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternal FromDomain(ApprovalRuleKey key, string error)
    {
        ApprovalRuleKeyInternal keyInternal = ApprovalRuleKeyInternalConverter.FromDomain(key);

        var result = new UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternal(keyInternal, error);

        return result;
    }
}
