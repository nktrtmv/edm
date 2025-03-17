using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.Edges;

internal static class ApprovalGraphEdgeDbConverter
{
    internal static ApprovalGraphEdgeDb FromDomain(ApprovalGraphEdge edge)
    {
        var id = IdConverterTo.ToString(edge.Id);

        var fromNodeId = IdConverterTo.ToString(edge.FromNodeId);

        var toNodeId = IdConverterTo.ToString(edge.ToNodeId);

        EntityConditionDb condition = EntityConditionDbConverter.FromDomain(edge.Condition);

        var result = new ApprovalGraphEdgeDb
        {
            Id = id,
            FromNodeId = fromNodeId,
            ToNodeId = toNodeId,
            Condition = condition
        };

        return result;
    }

    internal static ApprovalGraphEdge ToDomain(ApprovalGraphEdgeDb edge)
    {
        Id<ApprovalGraphEdge> id = IdConverterFrom<ApprovalGraphEdge>.FromString(edge.Id);

        Id<ApprovalGraphNode> fromNodeId = IdConverterFrom<ApprovalGraphNode>.FromString(edge.FromNodeId);

        Id<ApprovalGraphNode> toNodeId = IdConverterFrom<ApprovalGraphNode>.FromString(edge.ToNodeId);

        EntityCondition condition = EntityConditionDbConverter.ToDomain(edge.Condition);

        ApprovalGraphEdge result = ApprovalGraphEdgeFactory.CreateFrom(id, fromNodeId, toNodeId, condition);

        return result;
    }
}
