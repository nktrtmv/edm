using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.GetAll.Contracts.Graphs;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.GetAll.Contracts;

public sealed class GetAllApprovalGraphsQueryResponseBff
{
    public required GetAllApprovalGraphsQueryResponseGraphBff[] Graphs { get; init; }
}
