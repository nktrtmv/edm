using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Delete.Contracts;

internal static class DeleteApprovalGraphsCommandBffConverter
{
    internal static DeleteApprovalGraphsCommand ToDto(DeleteApprovalGraphsCommandBff command, string currentUserId)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.ToDto(command.ApprovalRuleKey);

        var result = new DeleteApprovalGraphsCommand
        {
            ApprovalRuleKey = approvalRuleKey,
            GraphId = command.GraphId,
            CurrentUserId = currentUserId,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
