using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts.Rules;

public sealed class UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleBff
{
    public required ApprovalRuleKeyBff Key { get; init; }
    public required string Error { get; init; }
}
