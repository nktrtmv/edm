using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.ChiefApprovals;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Edges;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Statuses;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs;

public sealed class ApprovalGraphBff
{
    public required string Id { get; init; }
    public required ApprovalGraphStatusBff Status { get; init; }
    public required ApprovalGraphNodeBff[] Nodes { get; init; }
    public required ApprovalGraphEdgeBff[] Edges { get; init; }
    public required ChiefApprovalStageBff ChiefApproval { get; init; }
    public required string FrontMetadata { get; init; }
    public required string DisplayName { get; init; }
    public required string Tag { get; init; }
}
