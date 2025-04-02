using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Types;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages;

public sealed class ApprovalGraphStageNodeBff : ApprovalGraphNodeBff
{
    public required string DisplayName { get; init; }
    public string? Label { get; init; } = null;
    public required ApprovalGraphStageTypeBff Type { get; init; }
    public required ApprovalGraphStageSetBff[] Sets { get; init; }
}
