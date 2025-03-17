using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Types;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.Nodes.Inheritors.Stages.Sets;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.Nodes.Inheritors.Stages.Types;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.Nodes.Inheritors.Stages;

internal static class ApprovalGraphStageNodeInternalConverter
{
    internal static ApprovalGraphStageNodeDto ToDto(ApprovalGraphStageNodeInternal node)
    {
        ApprovalGraphStageTypeDto type =
            ApprovalGraphStageTypeInternalConverter.ToDto(node.Type);

        ApprovalGraphStageSetDto[] sets =
            node.Sets.Select(ApprovalGraphStageSetInternalConverter.ToDto).ToArray();

        var result = new ApprovalGraphStageNodeDto
        {
            DisplayName = node.DisplayName,
            Label = node.Label,
            Type = type,
            Sets = { sets }
        };

        return result;
    }

    internal static ApprovalGraphNodeInternal FromDto(ApprovalGraphStageNodeDto node, Id<ApprovalGraphNodeInternal> id)
    {
        ApprovalGraphStageTypeInternal type =
            ApprovalGraphStageTypeInternalConverter.FromDto(node.Type);

        ApprovalGraphStageSetInternal[] sets =
            node.Sets.Select(ApprovalGraphStageSetInternalConverter.FromDto).ToArray();

        var result = new ApprovalGraphStageNodeInternal(
            id,
            node.DisplayName,
            node.Label,
            type,
            sets);

        return result;
    }
}
