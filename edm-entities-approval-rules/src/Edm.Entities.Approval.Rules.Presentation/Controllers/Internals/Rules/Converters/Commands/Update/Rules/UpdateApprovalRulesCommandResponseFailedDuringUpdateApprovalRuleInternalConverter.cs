using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Rules;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Commands.Update.Rules;

internal static class UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternalConverter
{
    internal static UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRule ToDto(UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternal rule)
    {
        ApprovalRuleKeyDto key = ApprovalRuleKeyInternalConverter.ToDto(rule.Key);

        var result = new UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRule
        {
            Key = key,
            Error = rule.Error
        };

        return result;
    }
}
