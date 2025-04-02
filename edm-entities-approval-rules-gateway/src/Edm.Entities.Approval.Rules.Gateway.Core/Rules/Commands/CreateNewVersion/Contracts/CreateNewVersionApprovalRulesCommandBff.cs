using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.CreateNewVersion.Contracts;

public sealed class CreateNewVersionApprovalRulesCommandBff
{
    public required ApprovalRuleKeyBff OriginalApprovalRuleKey { get; init; }
}
