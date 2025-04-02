using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Deactivate.Contracts;

public sealed class DeactivateApprovalRulesCommandBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
    public required string Comment { get; init; }
    public required string ConcurrencyToken { get; init; }
}
