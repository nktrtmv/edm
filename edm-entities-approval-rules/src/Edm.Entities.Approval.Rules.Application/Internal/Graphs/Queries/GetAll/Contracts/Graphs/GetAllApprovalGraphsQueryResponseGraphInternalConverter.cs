using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Statuses;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.GetAll.Contracts.Graphs;

internal static class GetAllApprovalGraphsQueryResponseGraphInternalConverter
{
    internal static GetAllApprovalGraphsQueryResponseGraphInternal FromDomain(ApprovalGraph graph)
    {
        Id<GetAllApprovalGraphsQueryResponseGraphInternal> id = IdConverterFrom<GetAllApprovalGraphsQueryResponseGraphInternal>.From(graph.Id);

        ApprovalGraphStatusInternal status = ApprovalGraphStatusInternalConverter.FromDomain(graph.Status);

        var result = new GetAllApprovalGraphsQueryResponseGraphInternal(id, status, graph.DisplayName, graph.Tag);

        return result;
    }
}
