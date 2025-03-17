using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Create.Contracts;

internal static class CreateApprovalGraphsCommandBffConverter
{
    internal static CreateApprovalGraphsCommand ToDto(CreateApprovalGraphsCommandBff command, string currentUserId)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.ToDto(command.ApprovalRuleKey);

        var result = new CreateApprovalGraphsCommand
        {
            ApprovalRuleKey = approvalRuleKey,
            DisplayName = command.DisplayName,
            CurrentUserId = currentUserId
        };

        return result;
    }
}
