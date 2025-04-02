using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Deactivate.Contracts;

internal static class DeactivateApprovalRulesCommandBffConverter
{
    internal static DeactivateApprovalRulesCommand ToDto(DeactivateApprovalRulesCommandBff command, string currentUserId)
    {
        var key = ApprovalRuleKeyBffConverter.ToDto(command.ApprovalRuleKey);

        var result = new DeactivateApprovalRulesCommand
        {
            Key = key,
            Comment = command.Comment,
            CurrentUserId = currentUserId,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
