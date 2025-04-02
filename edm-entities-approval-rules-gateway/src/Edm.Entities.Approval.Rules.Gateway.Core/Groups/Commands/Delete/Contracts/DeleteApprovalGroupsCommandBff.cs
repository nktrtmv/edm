using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Delete.Contracts;

public sealed class DeleteApprovalGroupsCommandBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
    public required string GroupId { get; init; }
    public required string ConcurrencyToken { get; init; }
}
