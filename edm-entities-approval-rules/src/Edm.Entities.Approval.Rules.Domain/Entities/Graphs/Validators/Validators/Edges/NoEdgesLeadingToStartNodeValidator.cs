using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Validators.Validators.Edges;

internal static class NoEdgesLeadingToStartNodeValidator
{
    internal static void Validate(ApprovalGraphEdge[] edges, ApprovalGraphNode startNode)
    {
        ApprovalGraphEdge[] incomingEdgesToStartNode = edges.Where(e => e.ToNodeId == startNode.Id).ToArray();

        if (incomingEdgesToStartNode.Length != 0)
        {
            string incomingEdges = string.Join<ApprovalGraphEdge>(", ", incomingEdgesToStartNode);

            throw new ApplicationException($"The start node must not have incoming edges.\nIncomingEdges: [{incomingEdges}]");
        }
    }
}
