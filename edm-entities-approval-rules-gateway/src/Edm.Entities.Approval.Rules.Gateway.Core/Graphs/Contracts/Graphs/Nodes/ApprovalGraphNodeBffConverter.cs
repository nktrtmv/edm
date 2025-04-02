using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Ends;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Starts;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Transits;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes;

internal static class ApprovalGraphNodeBffConverter
{
    internal static ApprovalGraphNodeBff FromDto(ApprovalGraphNodeDto node, ApprovalEnrichersContext context)
    {
        ApprovalGraphNodeBff result = node.ValueCase switch
        {
            ApprovalGraphNodeDto.ValueOneofCase.AsEnd => ApprovalGraphEndNodeBffConverter.FromDto(node.Id),
            ApprovalGraphNodeDto.ValueOneofCase.AsStage => ApprovalGraphStageNodeBffConverter.FromDto(node.Id, node.AsStage, context),
            ApprovalGraphNodeDto.ValueOneofCase.AsStart => ApprovalGraphStartNodeBffConverter.FromDto(node.Id),
            ApprovalGraphNodeDto.ValueOneofCase.AsTransit => ApprovalGraphTransitNodeBffConverter.FromDto(node.Id),
            _ => throw new ArgumentTypeOutOfRangeException(node)
        };

        return result;
    }

    internal static ApprovalGraphNodeDto ToDto(ApprovalGraphNodeBff node)
    {
        var result = node switch
        {
            ApprovalGraphEndNodeBff => ApprovalGraphEndNodeBffConverter.ToDto(node.Id),
            ApprovalGraphStageNodeBff n => ApprovalGraphStageNodeBffConverter.ToDto(n),
            ApprovalGraphStartNodeBff => ApprovalGraphStartNodeBffConverter.ToDto(node.Id),
            ApprovalGraphTransitNodeBff => ApprovalGraphTransitNodeBffConverter.ToDto(node.Id),
            _ => throw new ArgumentTypeOutOfRangeException(node)
        };

        return result;
    }
}
