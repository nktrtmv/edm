using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Graphs.ChiefApprovals;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Graphs.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Graphs.Nodes;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Graphs;

internal static class ApprovalGraphsUsedAttributesIdsCollector
{
    internal static HashSet<int> Collect(ApprovalGraph[] graphs)
    {
        var result = new HashSet<int>();

        foreach (ApprovalGraph graph in graphs)
        {
            Collect(result, graph);
        }

        return result;
    }

    private static void Collect(HashSet<int> attributesIds, ApprovalGraph graph)
    {
        ApprovalGraphChiefApprovalUsedAttributesIdsCollector.Collect(attributesIds, graph.ChiefApproval);

        foreach (ApprovalGraphEdge edge in graph.Edges)
        {
            ApprovalGraphEdgeUsedAttributesIdsCollector.Collect(attributesIds, edge);
        }

        foreach (ApprovalGraphNode node in graph.Nodes)
        {
            ApprovalGraphNodeUsedAttributesIdsCollector.Collect(attributesIds, node);
        }
    }
}
