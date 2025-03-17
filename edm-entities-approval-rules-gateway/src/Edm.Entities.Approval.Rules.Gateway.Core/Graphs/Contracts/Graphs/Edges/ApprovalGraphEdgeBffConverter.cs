using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Edges;

internal static class ApprovalGraphEdgeBffConverter
{
    internal static ApprovalGraphEdgeBff FromDto(ApprovalGraphEdgeDto edges, ApprovalEnrichersContext context)
    {
        var condition = EntityConditionBffConverter.FromDto(edges.Condition, context);

        var result = new ApprovalGraphEdgeBff
        {
            Id = edges.Id,
            FromNodeId = edges.FromNodeId,
            ToNodeId = edges.ToNodeId,
            Condition = condition
        };

        return result;
    }

    internal static ApprovalGraphEdgeDto ToDto(ApprovalGraphEdgeBff edge)
    {
        var condition = EntityConditionBffConverter.ToDto(edge.Condition);

        var result = new ApprovalGraphEdgeDto
        {
            Id = edge.Id,
            FromNodeId = edge.FromNodeId,
            ToNodeId = edge.ToNodeId,
            Condition = condition
        };

        return result;
    }
}
