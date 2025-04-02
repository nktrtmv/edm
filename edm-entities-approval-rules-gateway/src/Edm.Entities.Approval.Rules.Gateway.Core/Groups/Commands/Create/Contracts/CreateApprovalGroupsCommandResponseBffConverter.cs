using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Create.Contracts;

internal static class CreateApprovalGroupsCommandResponseBffConverter
{
    internal static CreateApprovalGroupsCommandResponseBff FromDto(
        CreateApprovalGroupsCommandResponse response,
        ApprovalRuleKeyBff approvalRuleKey)
    {
        var result = new CreateApprovalGroupsCommandResponseBff
        {
            GroupId = response.GroupId,
            ApprovalRuleKey = approvalRuleKey
        };

        return result;
    }
}
