using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.GetAll.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.GetAll.Contracts;

internal static class GetAllApprovalGraphsQueryResponseInternalConverter
{
    internal static GetAllApprovalGraphsQueryResponseInternal FromDomain(ApprovalGraph[] graphs)
    {
        GetAllApprovalGraphsQueryResponseGraphInternal[] graphsInternal =
            graphs.Select(GetAllApprovalGraphsQueryResponseGraphInternalConverter.FromDomain).ToArray();

        var result = new GetAllApprovalGraphsQueryResponseInternal(graphsInternal);

        return result;
    }
}
