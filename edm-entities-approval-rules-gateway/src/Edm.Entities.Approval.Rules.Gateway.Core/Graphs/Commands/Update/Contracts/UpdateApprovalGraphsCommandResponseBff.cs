using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Update.Contracts;

public sealed class UpdateApprovalGraphsCommandResponseBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
}
