using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Create.Contracts;

public sealed class CreateApprovalGraphsCommandResponseBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
    public required string GraphId { get; init; }
}
