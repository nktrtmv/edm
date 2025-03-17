using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Update.Contracts;

public sealed class UpdateApprovalGroupsCommandBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
    public required ApprovalGroupBff Group { get; init; }
    public required string ConcurrencyToken { get; init; }
}
