using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Create.Contracts.Kinds;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Create.Contracts;

public sealed class CreateApprovalGroupsCommandBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
    public required CreateApprovalGroupsCommandKindBff Kind { get; init; }
    public required string DisplayName { get; init; }
}
