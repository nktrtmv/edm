using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Ends;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Starts;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Validators.Validators.Routes;

internal static class AllRoutesAreFinalizedByEndNodeAndGraphConnectivityValidator
{
    internal static void Validate(
        Dictionary<Id<ApprovalGraphNode>, ApprovalGraphEdge[]> edgesByFrom,
        Dictionary<Id<ApprovalGraphNode>, ApprovalGraphNode> nodesById)
    {
        var pendingNodesIds = new Queue<Id<ApprovalGraphNode>>();
        var passedNodesIds = new HashSet<Id<ApprovalGraphNode>>();

        Id<ApprovalGraphNode> startNodeId = nodesById.Single(n => n.Value is ApprovalGraphStartNode).Key;

        pendingNodesIds.Enqueue(startNodeId);

        while (pendingNodesIds.Any())
        {
            Id<ApprovalGraphNode> currentNodeId = pendingNodesIds.Dequeue();

            passedNodesIds.Add(currentNodeId);

            ApprovalGraphEdge[]? possibleEdges = edgesByFrom.GetValueOrDefault(currentNodeId);

            if (possibleEdges == null)
            {
                ApprovalGraphNode currentNode = nodesById[currentNodeId];

                if (currentNode is not ApprovalGraphEndNode)
                {
                    throw new ArgumentException($"Detected a node without outgoing edges and is not of type End ({currentNode}).");
                }

                continue;
            }

            foreach (ApprovalGraphEdge edge in possibleEdges)
            {
                if (!passedNodesIds.Contains(edge.ToNodeId))
                {
                    pendingNodesIds.Enqueue(edge.ToNodeId);
                }
            }
        }

        if (nodesById.Count != passedNodesIds.Count)
        {
            throw new ArgumentException($"All nodes shall participate in routing (nodes count: {nodesById.Count}, participant nodes count: {passedNodesIds.Count}).");
        }
    }
}
