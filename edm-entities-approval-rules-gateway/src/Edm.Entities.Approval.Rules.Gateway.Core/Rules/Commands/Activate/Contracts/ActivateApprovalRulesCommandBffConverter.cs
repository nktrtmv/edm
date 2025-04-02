using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Activate.Contracts;

internal static class ActivateApprovalRulesCommandBffConverter
{
    internal static ActivateApprovalRulesCommand ToDto(ActivateApprovalRulesCommandBff command, string currentUserId)
    {
        var key = ApprovalRuleKeyBffConverter.ToDto(command.ApprovalRuleKey);

        var result = new ActivateApprovalRulesCommand
        {
            Key = key,
            Comment = command.Comment,
            CurrentUserId = currentUserId,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
