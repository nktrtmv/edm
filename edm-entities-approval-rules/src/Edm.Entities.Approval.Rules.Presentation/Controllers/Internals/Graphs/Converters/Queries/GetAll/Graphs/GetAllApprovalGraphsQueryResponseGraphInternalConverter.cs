using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.GetAll.Contracts.Graphs;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.Statuses;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Queries.GetAll.Graphs;

internal static class GetAllApprovalGraphsQueryResponseGraphInternalConverter
{
    internal static GetAllApprovalGraphsQueryResponseGraph ToDto(GetAllApprovalGraphsQueryResponseGraphInternal graph)
    {
        var id = IdConverterTo.ToString(graph.Id);

        ApprovalGraphStatusDto status = ApprovalGraphStatusInternalConverter.ToDto(graph.Status);

        var result = new GetAllApprovalGraphsQueryResponseGraph
        {
            Id = id,
            Status = status,
            DisplayName = graph.DisplayName,
            Tag = graph.Tag
        };

        return result;
    }
}
