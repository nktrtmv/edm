using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.CreateNewVersion.Contracts;

internal static class CreateNewVersionApprovalRulesCommandResponseBffConverter
{
    internal static CreateNewVersionApprovalRulesCommandResponseBff FromDto(CreateNewVersionApprovalRulesCommandResponse response)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.FromDto(response.Key);

        var result = new CreateNewVersionApprovalRulesCommandResponseBff
        {
            ApprovalRuleKey = approvalRuleKey
        };

        return result;
    }
}
