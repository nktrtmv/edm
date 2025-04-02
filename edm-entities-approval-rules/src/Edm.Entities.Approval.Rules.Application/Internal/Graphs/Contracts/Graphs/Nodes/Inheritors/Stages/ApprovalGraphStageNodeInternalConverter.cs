using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Types;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages;

internal static class ApprovalGraphStageNodeInternalConverter
{
    internal static ApprovalGraphStageNodeInternal FromDomain(Id<ApprovalGraphNodeInternal> id, ApprovalGraphStageNode node)
    {
        ApprovalGraphStageTypeInternal type =
            ApprovalGraphStageTypeInternalConverter.FromDomain(node.Type);

        ApprovalGraphStageSetInternal[] sets =
            node.Sets.Select(ApprovalGraphStageSetInternalConverter.FromDomain).ToArray();

        var result = new ApprovalGraphStageNodeInternal(id, node.DisplayName, node.Label, type, sets);

        return result;
    }

    internal static ApprovalGraphNode ToDomain(Id<ApprovalGraphNode> id, ApprovalGraphStageNodeInternal node)
    {
        ApprovalGraphStageType type =
            ApprovalGraphStageTypeInternalConverter.ToDomain(node.Type);

        ApprovalGraphStageSet[] sets =
            node.Sets.Select(ApprovalGraphStageSetInternalConverter.ToDomain).ToArray();

        ApprovalGraphNode result = ApprovalGraphStageNodeFactory.CreateFrom(id, node.DisplayName, node.Label, type, sets);

        return result;
    }
}
