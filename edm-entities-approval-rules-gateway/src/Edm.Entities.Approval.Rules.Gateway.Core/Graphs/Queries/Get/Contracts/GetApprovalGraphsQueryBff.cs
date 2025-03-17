using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.Get.Contracts;

public sealed class GetApprovalGraphsQueryBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
    public required string GraphId { get; init; }
}
