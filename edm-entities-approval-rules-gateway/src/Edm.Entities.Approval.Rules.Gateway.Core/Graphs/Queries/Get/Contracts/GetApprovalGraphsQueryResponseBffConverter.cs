using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.Get.Contracts;

internal static class GetApprovalGraphsQueryResponseBffConverter
{
    internal static GetApprovalGraphsQueryResponseBff FromDto(GetApprovalGraphsQueryResponse response, ApprovalEnrichersContext context)
    {
        var graph = ApprovalGraphBffConverter.FromDto(response.Graph, context);

        var result = new GetApprovalGraphsQueryResponseBff
        {
            Graph = graph,
            ConcurrencyToken = response.ConcurrencyToken
        };

        return result;
    }
}
