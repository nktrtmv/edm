using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.GetAll.Contracts.Graphs;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.GetAll.Contracts;

public sealed class GetAllApprovalGraphsQueryResponseInternal
{
    internal GetAllApprovalGraphsQueryResponseInternal(GetAllApprovalGraphsQueryResponseGraphInternal[] graphs)
    {
        Graphs = graphs;
    }

    public GetAllApprovalGraphsQueryResponseGraphInternal[] Graphs { get; }
}
