using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Validators.Validators.Edges;

internal static class AllEdgesHasCorrespondedNodesValidator
{
    internal static void Validate(IEnumerable<ApprovalGraphEdge> edges, Dictionary<Id<ApprovalGraphNode>, ApprovalGraphNode> nodesById)
    {
        foreach (ApprovalGraphEdge edge in edges)
        {
            ApprovalGraphNode? toNode = nodesById.GetValueOrDefault(edge.ToNodeId);

            if (toNode is null)
            {
                throw new ArgumentException($"Edge ({edge}) points to non-existing 'to' node (id: {edge.ToNodeId}).");
            }

            ApprovalGraphNode? fromNode = nodesById.GetValueOrDefault(edge.FromNodeId);

            if (fromNode is null)
            {
                throw new ArgumentException($"Edge ({edge}) points from non-existing 'from' node (id: {edge.FromNodeId}).");
            }
        }
    }
}
