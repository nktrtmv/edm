using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Create.Contracts;

public sealed class CreateApprovalGroupsCommandResponseBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
    public required string GroupId { get; init; }
}
