using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.Get.Contracts;

public sealed class GetApprovalGroupsQueryResponseBff
{
    public required ApprovalGroupBff Group { get; init; }
    public required string ConcurrencyToken { get; init; }
}
