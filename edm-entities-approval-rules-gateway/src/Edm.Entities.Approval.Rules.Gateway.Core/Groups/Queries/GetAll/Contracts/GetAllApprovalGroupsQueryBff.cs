using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts;

public sealed class GetAllApprovalGroupsQueryBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
}
