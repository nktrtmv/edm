using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.GetAll.Contracts;

public sealed class GetAllApprovalGraphsQueryBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
}
