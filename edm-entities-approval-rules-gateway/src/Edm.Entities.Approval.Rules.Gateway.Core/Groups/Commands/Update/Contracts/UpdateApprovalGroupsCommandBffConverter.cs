using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Update.Contracts;

internal static class UpdateApprovalGroupsCommandBffConverter
{
    internal static UpdateApprovalGroupsCommand ToDto(UpdateApprovalGroupsCommandBff command, string currentUserId)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.ToDto(command.ApprovalRuleKey);

        var group = ApprovalGroupBffConverter.ToDto(command.Group);

        var result = new UpdateApprovalGroupsCommand
        {
            ApprovalRuleKey = approvalRuleKey,
            Group = group,
            CurrentUserId = currentUserId,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
