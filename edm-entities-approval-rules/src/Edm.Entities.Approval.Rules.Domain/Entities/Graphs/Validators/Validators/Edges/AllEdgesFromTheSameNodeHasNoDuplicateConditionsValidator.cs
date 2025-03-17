using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Validators.Validators.Edges;

internal static class AllEdgesFromTheSameNodeHasNoDuplicateConditionsValidator
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

        int numberOfDuplicateConditions = edges
            .GroupBy(r => r.Condition)
            .Count(c => c.Count() > 1);

        if (numberOfDuplicateConditions != 0)
        {
            throw new ApplicationException($"Edges leading from the same node (id: {nodeId}) have {numberOfDuplicateConditions} duplicate conditions.");
        }
    }
}
