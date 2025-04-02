using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;

public sealed class ApprovalGraphEdge
{
    internal ApprovalGraphEdge(
        Id<ApprovalGraphEdge> id,
        Id<ApprovalGraphNode> fromNodeId,
        Id<ApprovalGraphNode> toNodeId,
        EntityCondition condition)
    {
        Id = id;
        FromNodeId = fromNodeId;
        ToNodeId = toNodeId;
        Condition = condition;
    }

    public Id<ApprovalGraphEdge> Id { get; }
    public Id<ApprovalGraphNode> FromNodeId { get; }
    public Id<ApprovalGraphNode> ToNodeId { get; }
    public EntityCondition Condition { get; }

    public override string ToString()
    {
        return $"{{ Id: {Id} }}";
    }
}
