using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Edges;

internal static class ApprovalGraphEdgeInternalConverter
{
    internal static ApprovalGraphEdgeInternal FromDomain(ApprovalGraphEdge edge)
    {
        Id<ApprovalGraphEdgeInternal> id = IdConverterFrom<ApprovalGraphEdgeInternal>.From(edge.Id);

        Id<ApprovalGraphNodeInternal> fromNodeId = IdConverterFrom<ApprovalGraphNodeInternal>.From(edge.FromNodeId);

        Id<ApprovalGraphNodeInternal> toNodeId = IdConverterFrom<ApprovalGraphNodeInternal>.From(edge.ToNodeId);

        EntityConditionInternal condition = EntityConditionInternalConverter.FromDomain(edge.Condition);

        var result = new ApprovalGraphEdgeInternal(id, fromNodeId, toNodeId, condition);

        return result;
    }

    internal static ApprovalGraphEdge ToDomain(ApprovalGraphEdgeInternal edge)
    {
        Id<ApprovalGraphEdge> id = IdConverterFrom<ApprovalGraphEdge>.From(edge.Id);

        Id<ApprovalGraphNode> fromNodeId = IdConverterFrom<ApprovalGraphNode>.From(edge.FromNodeId);

        Id<ApprovalGraphNode> toNodeId = IdConverterFrom<ApprovalGraphNode>.From(edge.ToNodeId);

        EntityCondition condition = EntityConditionInternalConverter.ToDomain(edge.Condition);

        ApprovalGraphEdge result = ApprovalGraphEdgeFactory.CreateFrom(id, fromNodeId, toNodeId, condition);

        return result;
    }
}
