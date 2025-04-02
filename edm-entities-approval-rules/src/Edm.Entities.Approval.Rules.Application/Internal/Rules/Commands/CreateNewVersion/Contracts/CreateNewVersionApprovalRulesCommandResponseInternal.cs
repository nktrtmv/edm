using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.CreateNewVersion.Contracts;

public sealed class CreateNewVersionApprovalRulesCommandResponseInternal
{
    internal CreateNewVersionApprovalRulesCommandResponseInternal(ApprovalRuleKeyInternal key)
    {
        Key = key;
    }

    public ApprovalRuleKeyInternal Key { get; }
}
