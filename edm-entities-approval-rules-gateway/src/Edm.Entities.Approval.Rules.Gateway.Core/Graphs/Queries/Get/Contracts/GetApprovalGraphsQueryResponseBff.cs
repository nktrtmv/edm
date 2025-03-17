using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.Get.Contracts;

public sealed class GetApprovalGraphsQueryResponseBff
{
    public required ApprovalGraphBff Graph { get; init; }
    public required string ConcurrencyToken { get; init; }
}
