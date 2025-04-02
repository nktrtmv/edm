using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Delete.Contracts;

internal static class DeleteApprovalGroupsCommandBffConverter
{
    internal static DeleteApprovalGroupsCommand ToDto(DeleteApprovalGroupsCommandBff command, string currentUserId)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.ToDto(command.ApprovalRuleKey);

        var result = new DeleteApprovalGroupsCommand
        {
            ApprovalRuleKey = approvalRuleKey,
            GroupId = command.GroupId,
            CurrentUserId = currentUserId,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
