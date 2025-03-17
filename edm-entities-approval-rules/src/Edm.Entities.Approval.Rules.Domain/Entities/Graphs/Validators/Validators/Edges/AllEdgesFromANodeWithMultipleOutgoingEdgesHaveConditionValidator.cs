using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Nones;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Validators.Validators.Edges;

internal static class AllEdgesFromANodeWithMultipleOutgoingEdgesHaveConditionValidator
{
    internal static void Validate(Dictionary<Id<ApprovalGraphNode>, ApprovalGraphEdge[]> edgesByFrom)
    {
        foreach (KeyValuePair<Id<ApprovalGraphNode>, ApprovalGraphEdge[]> edgesFrom in edgesByFrom)
        {
            Validate(edgesFrom.Key, edgesFrom.Value);
        }
    }

    private static void Validate(Id<ApprovalGraphNode> nodeId, ApprovalGraphEdge[] edges)
    {
        if (edges.Length < 2)
        {
            return;
        }

        ApprovalGraphEdge? edgeWithNoneCondition = edges.FirstOrDefault(e => e.Condition is EntityNoneCondition);

        if (edgeWithNoneCondition is not null)
        {
            throw new ApplicationException($"Edge ({edgeWithNoneCondition}) leading from a node (id: {nodeId}) with multiple outgoing edges must have a condition.");
        }
    }
}
