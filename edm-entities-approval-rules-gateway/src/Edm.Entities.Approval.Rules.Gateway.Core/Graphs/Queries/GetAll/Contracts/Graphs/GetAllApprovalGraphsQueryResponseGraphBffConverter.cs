using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Statuses;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.GetAll.Contracts.Graphs;

internal static class GetAllApprovalGraphsQueryResponseGraphBffConverter
{
    internal static GetAllApprovalGraphsQueryResponseGraphBff FromDto(GetAllApprovalGraphsQueryResponseGraph graph)
    {
        var status = ApprovalGraphStatusBffConverter.FromDto(graph.Status);

        var result = new GetAllApprovalGraphsQueryResponseGraphBff
        {
            Id = graph.Id,
            Status = status,
            DisplayName = graph.DisplayName,
            Tag = graph.Tag
        };

        return result;
    }
}
