using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Create.Contracts.Kinds;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Create.Contracts;

internal static class CreateApprovalGroupsCommandBffConverter
{
    internal static CreateApprovalGroupsCommand ToDto(CreateApprovalGroupsCommandBff command, string currentUserId)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.ToDto(command.ApprovalRuleKey);

        var kind = CreateApprovalGroupsCommandKindBffConverter.ToDto(command.Kind);

        var result = new CreateApprovalGroupsCommand
        {
            ApprovalRuleKey = approvalRuleKey,
            Kind = kind,
            DisplayName = command.DisplayName,
            CurrentUserId = currentUserId
        };

        return result;
    }
}
