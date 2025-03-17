using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.GetAll.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.GetAll.Contracts;

internal static class GetAllApprovalGraphsQueryResponseBffConverter
{
    internal static GetAllApprovalGraphsQueryResponseBff FromDto(GetAllApprovalGraphsQueryResponse response)
    {
        GetAllApprovalGraphsQueryResponseGraphBff[] graphs =
            response.Graphs.Select(GetAllApprovalGraphsQueryResponseGraphBffConverter.FromDto).ToArray();

        var result = new GetAllApprovalGraphsQueryResponseBff
        {
            Graphs = graphs
        };

        return result;
    }
}
