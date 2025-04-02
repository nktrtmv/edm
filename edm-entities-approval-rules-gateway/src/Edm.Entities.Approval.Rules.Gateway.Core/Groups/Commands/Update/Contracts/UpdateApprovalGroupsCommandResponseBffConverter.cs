using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Update.Contracts;

internal static class UpdateApprovalGroupsCommandResponseBffConverter
{
    internal static UpdateApprovalGroupsCommandResponseBff FromDto(ApprovalRuleKeyBff approvalRuleKey)
    {
        var result = new UpdateApprovalGroupsCommandResponseBff
        {
            ApprovalRuleKey = approvalRuleKey
        };

        return result;
    }
}
