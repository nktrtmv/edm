using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Validators.Validators.Nodes;

internal static class AllNodesAreUsedValidator
{
    internal static void Validate(IEnumerable<ApprovalGraphEdge> edges, IEnumerable<Id<ApprovalGraphNode>> nodes)
    {
        var unusedNodesIds = new HashSet<Id<ApprovalGraphNode>>(nodes);

        foreach (ApprovalGraphEdge edge in edges)
        {
            unusedNodesIds.Remove(edge.FromNodeId);

            if (unusedNodesIds.Count == 0)
            {
                return;
            }

            unusedNodesIds.Remove(edge.ToNodeId);

            if (unusedNodesIds.Count == 0)
            {
                return;
            }
        }

        if (unusedNodesIds.Count > 0)
        {
            throw new ArgumentException($"There are {unusedNodesIds.Count} unused nodes with ids ({string.Join(", ", unusedNodesIds)}).");
        }
    }
}
