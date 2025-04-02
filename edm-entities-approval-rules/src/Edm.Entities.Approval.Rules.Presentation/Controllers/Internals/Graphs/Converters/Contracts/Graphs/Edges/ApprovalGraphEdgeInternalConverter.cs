using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Edges;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.Edges;

internal static class ApprovalGraphEdgeInternalConverter
{
    internal static ApprovalGraphEdgeDto ToDto(ApprovalGraphEdgeInternal edge)
    {
        var id = IdConverterTo.ToString(edge.Id);

        var fromNodeId = IdConverterTo.ToString(edge.FromNodeId);

        var toNodeId = IdConverterTo.ToString(edge.ToNodeId);

        EntityConditionDto condition = EntityConditionInternalConverter.ToDto(edge.Condition);

        var result = new ApprovalGraphEdgeDto
        {
            Id = id,
            FromNodeId = fromNodeId,
            ToNodeId = toNodeId,
            Condition = condition
        };

        return result;
    }

    internal static ApprovalGraphEdgeInternal FromDto(ApprovalGraphEdgeDto edge)
    {
        Id<ApprovalGraphEdgeInternal> id = IdConverterFrom<ApprovalGraphEdgeInternal>.FromString(edge.Id);

        Id<ApprovalGraphNodeInternal> fromNodeId = IdConverterFrom<ApprovalGraphNodeInternal>.FromString(edge.FromNodeId);

        Id<ApprovalGraphNodeInternal> toNodeId = IdConverterFrom<ApprovalGraphNodeInternal>.FromString(edge.ToNodeId);

        EntityConditionInternal condition = EntityConditionInternalConverter.FromDto(edge.Condition);

        var result = new ApprovalGraphEdgeInternal(id, fromNodeId, toNodeId, condition);

        return result;
    }
}
