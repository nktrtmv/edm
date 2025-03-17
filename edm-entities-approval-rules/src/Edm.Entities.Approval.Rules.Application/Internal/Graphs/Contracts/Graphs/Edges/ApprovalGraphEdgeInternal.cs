using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Edges;

public sealed class ApprovalGraphEdgeInternal
{
    public ApprovalGraphEdgeInternal(
        Id<ApprovalGraphEdgeInternal> id,
        Id<ApprovalGraphNodeInternal> fromNodeId,
        Id<ApprovalGraphNodeInternal> toNodeId,
        EntityConditionInternal condition)
    {
        Id = id;
        FromNodeId = fromNodeId;
        ToNodeId = toNodeId;
        Condition = condition;
    }

    public Id<ApprovalGraphEdgeInternal> Id { get; }
    public Id<ApprovalGraphNodeInternal> FromNodeId { get; }
    public Id<ApprovalGraphNodeInternal> ToNodeId { get; }
    public EntityConditionInternal Condition { get; }
}
