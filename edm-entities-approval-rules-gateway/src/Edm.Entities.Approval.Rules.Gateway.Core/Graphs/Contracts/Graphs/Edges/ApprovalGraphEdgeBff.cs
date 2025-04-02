using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Edges;

public sealed class ApprovalGraphEdgeBff
{
    public required string Id { get; init; }
    public required string FromNodeId { get; init; }
    public required string ToNodeId { get; init; }
    public required EntityConditionBff Condition { get; init; }
}
