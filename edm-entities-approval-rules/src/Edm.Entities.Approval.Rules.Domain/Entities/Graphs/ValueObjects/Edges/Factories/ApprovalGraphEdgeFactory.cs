using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges.Factories;

public static class ApprovalGraphEdgeFactory
{
    public static ApprovalGraphEdge CreateFrom(
        Id<ApprovalGraphEdge> id,
        Id<ApprovalGraphNode> from,
        Id<ApprovalGraphNode> to,
        EntityCondition condition)
    {
        var result = new ApprovalGraphEdge(id, from, to, condition);

        return result;
    }

    public static ApprovalGraphEdge CreateNew(
        Id<ApprovalGraphNode> from,
        Id<ApprovalGraphNode> to,
        EntityCondition condition)
    {
        var id = Id<ApprovalGraphEdge>.CreateNew();

        ApprovalGraphEdge result = CreateFrom(id, from, to, condition);

        return result;
    }
}
