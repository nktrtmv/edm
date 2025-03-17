using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Delete.Contracts;

public sealed class DeleteApprovalGraphsCommandBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
    public required string GraphId { get; init; }
    public required string ConcurrencyToken { get; init; }
}
