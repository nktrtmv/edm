using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts.Rules;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts;

internal static class UpdateApprovalRulesCommandResponseBffConverter
{
    internal static UpdateApprovalRulesCommandResponseBff FromDto(UpdateApprovalRulesCommandResponse response)
    {
        UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleBff[] failedDuringUpdateApprovalRules =
            response.FailedDuringUpdateApprovalRules.Select(UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleBffConverter.FromDto).ToArray();

        var result = new UpdateApprovalRulesCommandResponseBff
        {
            FailedDuringUpdateApprovalRules = failedDuringUpdateApprovalRules
        };

        return result;
    }
}
