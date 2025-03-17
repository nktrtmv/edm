using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages;

public sealed class ApprovalGraphStageNode : ApprovalGraphNode
{
    public ApprovalGraphStageNode(
        Id<ApprovalGraphNode> id,
        string displayName,
        string? label,
        ApprovalGraphStageType type,
        ApprovalGraphStageSet[] sets) : base(id)
    {
        DisplayName = displayName;
        Label = label;
        Type = type;
        Sets = sets;
    }

    public string DisplayName { get; }

    public string? Label { get; }

    public ApprovalGraphStageType Type { get; }

    public ApprovalGraphStageSet[] Sets { get; }

    public override string ToString()
    {
        string sets = string.Join<ApprovalGraphStageSet>(", ", Sets);

        return $"{{ {BaseToString()}, DisplayName: {DisplayName}, Label: {Label}, Type: {Type}, Sets: [{sets}] }}";
    }
}
