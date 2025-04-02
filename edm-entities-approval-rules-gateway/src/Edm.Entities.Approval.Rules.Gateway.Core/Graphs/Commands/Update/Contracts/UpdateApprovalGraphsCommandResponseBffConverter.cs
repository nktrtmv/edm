using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Update.Contracts;

internal static class UpdateApprovalGraphsCommandResponseBffConverter
{
    internal static UpdateApprovalGraphsCommandResponseBff FromDto(ApprovalRuleKeyBff approvalRuleKey)
    {
        var result = new UpdateApprovalGraphsCommandResponseBff
        {
            ApprovalRuleKey = approvalRuleKey
        };

        return result;
    }
}
