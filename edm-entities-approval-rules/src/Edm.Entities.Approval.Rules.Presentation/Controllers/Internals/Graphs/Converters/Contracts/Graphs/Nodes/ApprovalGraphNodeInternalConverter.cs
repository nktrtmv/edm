using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Ends;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Starts;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Transits;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.Nodes.Inheritors.Stages;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.Nodes;

internal static class ApprovalGraphNodeInternalConverter
{
    internal static ApprovalGraphNodeDto ToDto(ApprovalGraphNodeInternal node)
    {
        ApprovalGraphNodeDto result = node switch
        {
            ApprovalGraphEndNodeInternal =>
                new ApprovalGraphNodeDto { AsEnd = new ApprovalGraphEndNodeDto() },

            ApprovalGraphStageNodeInternal n =>
                new ApprovalGraphNodeDto { AsStage = ApprovalGraphStageNodeInternalConverter.ToDto(n) },

            ApprovalGraphStartNodeInternal =>
                new ApprovalGraphNodeDto { AsStart = new ApprovalGraphStartNodeDto() },

            ApprovalGraphTransitNodeInternal =>
                new ApprovalGraphNodeDto { AsTransit = new ApprovalGraphTransitNodeDto() },

            _ => throw new ArgumentTypeOutOfRangeException(node)
        };

        var id = IdConverterTo.ToString(node.Id);

        result.Id = id;

        return result;
    }

    internal static ApprovalGraphNodeInternal FromDto(ApprovalGraphNodeDto node)
    {
        Id<ApprovalGraphNodeInternal> id = IdConverterFrom<ApprovalGraphNodeInternal>.FromString(node.Id);

        ApprovalGraphNodeInternal result = node.ValueCase switch
        {
            ApprovalGraphNodeDto.ValueOneofCase.AsEnd => new ApprovalGraphEndNodeInternal(id),
            ApprovalGraphNodeDto.ValueOneofCase.AsStage => ApprovalGraphStageNodeInternalConverter.FromDto(node.AsStage, id),
            ApprovalGraphNodeDto.ValueOneofCase.AsStart => new ApprovalGraphStartNodeInternal(id),
            ApprovalGraphNodeDto.ValueOneofCase.AsTransit => new ApprovalGraphTransitNodeInternal(id),
            _ => throw new ArgumentTypeOutOfRangeException(node)
        };

        return result;
    }
}
