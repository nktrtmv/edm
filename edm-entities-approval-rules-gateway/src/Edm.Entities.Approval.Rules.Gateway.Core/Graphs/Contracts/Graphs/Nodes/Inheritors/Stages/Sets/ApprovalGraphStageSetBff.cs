using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets.Groups;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets;

public sealed class ApprovalGraphStageSetBff
{
    public required EntityConditionBff Condition { get; init; }
    public required ApprovalGraphStageGroupBff[] Groups { get; init; }
}
