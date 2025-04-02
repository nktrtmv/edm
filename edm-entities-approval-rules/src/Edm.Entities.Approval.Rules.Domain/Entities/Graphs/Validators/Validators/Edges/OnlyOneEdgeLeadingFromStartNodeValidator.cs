using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Validators.Validators.Edges;

internal static class OnlyOneEdgeLeadingFromStartNodeValidator
{
    internal static void Validate(ApprovalGraphEdge[] edges, ApprovalGraphNode startNode)
    {
        int numberOfOutgoingEdgesFromStartNode = edges.Count(e => e.FromNodeId == startNode.Id);

        if (numberOfOutgoingEdgesFromStartNode != 1)
        {
            throw new ApplicationException($"Start node must have exactly 1 outgoing edge but {numberOfOutgoingEdgesFromStartNode} edges found.");
        }
    }
}
