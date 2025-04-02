using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.Factories;

public static class ApprovalGraphStageNodeFactory
{
    public static ApprovalGraphNode CreateNew(string displayName)
    {
        var id = Id<ApprovalGraphNode>.CreateNew();

        ApprovalGraphStageSet[] sets = [];

        ApprovalGraphNode result = CreateFrom(id, displayName, null, ApprovalGraphStageType.Sequential, sets);

        return result;
    }

    public static ApprovalGraphNode CreateFrom(
        Id<ApprovalGraphNode> id,
        string displayName,
        string? label,
        ApprovalGraphStageType type,
        ApprovalGraphStageSet[] sets)
    {
        var result = new ApprovalGraphStageNode(id, displayName, label, type, sets);

        return result;
    }
}
