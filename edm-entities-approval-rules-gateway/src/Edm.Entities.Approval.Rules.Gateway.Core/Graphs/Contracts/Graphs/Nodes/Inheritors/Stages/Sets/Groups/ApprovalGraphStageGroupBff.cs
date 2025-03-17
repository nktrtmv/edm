namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets.Groups;

public sealed class ApprovalGraphStageGroupBff
{
    public required string Id { get; init; }
    public string DisplayName { get; set; } = string.Empty;
}
