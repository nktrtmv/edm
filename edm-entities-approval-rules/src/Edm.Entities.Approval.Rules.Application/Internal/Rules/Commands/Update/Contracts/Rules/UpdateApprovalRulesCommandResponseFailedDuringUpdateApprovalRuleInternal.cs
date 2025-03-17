using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Rules;

public sealed class UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternal
{
    internal UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternal(ApprovalRuleKeyInternal key, string error)
    {
        Key = key;
        Error = error;
    }

    public ApprovalRuleKeyInternal Key { get; }
    public string Error { get; }
}
