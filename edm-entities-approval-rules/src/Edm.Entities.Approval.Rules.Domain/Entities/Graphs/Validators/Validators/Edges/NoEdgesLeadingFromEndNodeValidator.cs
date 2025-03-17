using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Validators.Validators.Edges;

internal static class NoEdgesLeadingFromEndNodeValidator
{
    internal static void Validate(ApprovalGraphEdge[] edges, ApprovalGraphNode endNode)
    {
        ApprovalGraphEdge[] outgoingEdgesFromEndNode = edges.Where(e => e.FromNodeId == endNode.Id).ToArray();

        if (outgoingEdgesFromEndNode.Length != 0)
        {
            string outgoingEdges = string.Join(", ", outgoingEdgesFromEndNode.Select(e => e.Id));

            throw new ApplicationException($"The end node must not have outgoing edges, but {outgoingEdgesFromEndNode.Length} outgoing edges ({outgoingEdges}) found.");
        }
    }
}
