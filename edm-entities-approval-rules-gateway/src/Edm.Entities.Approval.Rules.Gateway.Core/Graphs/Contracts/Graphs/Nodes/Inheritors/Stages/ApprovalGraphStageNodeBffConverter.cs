using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Types;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages;

internal static class ApprovalGraphStageNodeBffConverter
{
    internal static ApprovalGraphStageNodeBff FromDto(string id, ApprovalGraphStageNodeDto node, ApprovalEnrichersContext context)
    {
        ApprovalGraphStageSetBff[] groups =
            node.Sets.Select(s => ApprovalGraphStageSetBffConverter.FromDto(s, context)).ToArray();

        var type =
            ApprovalGraphStageTypeBffConverter.FromDto(node.Type);

        var result = new ApprovalGraphStageNodeBff
        {
            Id = id,
            DisplayName = node.DisplayName,
            Label = node.Label,
            Sets = groups,
            Type = type
        };

        return result;
    }

    internal static ApprovalGraphNodeDto ToDto(ApprovalGraphStageNodeBff node)
    {
        var type = ApprovalGraphStageTypeBffConverter.ToDto(node.Type);

        ApprovalGraphStageSetDto[] sets = node.Sets.Select(ApprovalGraphStageSetBffConverter.ToDto).ToArray();

        var asStage = new ApprovalGraphStageNodeDto
        {
            DisplayName = node.DisplayName,
            Label = node.Label,
            Type = type,
            Sets = { sets }
        };

        var result = new ApprovalGraphNodeDto
        {
            Id = node.Id,
            AsStage = asStage
        };

        return result;
    }
}
