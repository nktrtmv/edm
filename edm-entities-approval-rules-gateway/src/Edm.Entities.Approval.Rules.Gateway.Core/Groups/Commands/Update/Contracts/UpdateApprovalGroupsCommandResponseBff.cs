using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Update.Contracts;

public sealed class UpdateApprovalGroupsCommandResponseBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
}
