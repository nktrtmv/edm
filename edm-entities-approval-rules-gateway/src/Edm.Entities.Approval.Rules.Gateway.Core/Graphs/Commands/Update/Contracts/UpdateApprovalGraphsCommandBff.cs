using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Update.Contracts;

public sealed class UpdateApprovalGraphsCommandBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
    public required ApprovalGraphBff Graph { get; init; }
    public required string ConcurrencyToken { get; init; }
}
