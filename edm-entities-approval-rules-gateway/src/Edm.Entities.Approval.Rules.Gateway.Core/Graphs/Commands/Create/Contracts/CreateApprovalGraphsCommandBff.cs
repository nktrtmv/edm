using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Create.Contracts;

public sealed class CreateApprovalGraphsCommandBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
    public required string DisplayName { get; init; }
}
