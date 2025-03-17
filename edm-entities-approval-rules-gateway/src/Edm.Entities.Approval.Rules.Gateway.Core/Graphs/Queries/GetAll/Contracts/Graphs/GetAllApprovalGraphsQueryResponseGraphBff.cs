using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Statuses;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.GetAll.Contracts.Graphs;

public sealed class GetAllApprovalGraphsQueryResponseGraphBff
{
    public required string Id { get; init; }
    public required ApprovalGraphStatusBff Status { get; init; }
    public required string DisplayName { get; init; }
    public required string Tag { get; init; }
}
