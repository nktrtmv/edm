using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.CreateNewVersion.Contracts;

internal static class CreateNewVersionApprovalRulesCommandBffConverter
{
    internal static CreateNewVersionApprovalRulesCommand ToDto(CreateNewVersionApprovalRulesCommandBff command, string currentUserId)
    {
        var originalApprovalRuleKey = ApprovalRuleKeyBffConverter.ToDto(command.OriginalApprovalRuleKey);

        var result = new CreateNewVersionApprovalRulesCommand
        {
            OriginalApprovalRuleKey = originalApprovalRuleKey,
            CurrentUserId = currentUserId
        };

        return result;
    }
}
