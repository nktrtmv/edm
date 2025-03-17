using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts.Rules;

internal static class UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleBffConverter
{
    internal static UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleBff FromDto(UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRule rule)
    {
        var key = ApprovalRuleKeyBffConverter.FromDto(rule.Key);

        var result = new UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleBff
        {
            Key = key,
            Error = rule.Error
        };

        return result;
    }
}
