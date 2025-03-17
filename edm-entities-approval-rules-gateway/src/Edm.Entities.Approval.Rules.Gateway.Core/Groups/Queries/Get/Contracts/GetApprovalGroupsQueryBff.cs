using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.Get.Contracts;

public sealed class GetApprovalGroupsQueryBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
    public required string GroupId { get; init; }
}
