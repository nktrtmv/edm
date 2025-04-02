using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Markers;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.ChiefApprovals;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Statuses;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs;

public sealed class ApprovalGraph
{
    public ApprovalGraph(
        Id<ApprovalGraph> id,
        ApprovalGraphStatus status,
        ApprovalGraphEdge[] edges,
        ApprovalGraphNode[] nodes,
        ChiefApprovalStage chiefApproval,
        Metadata<Front> frontMetadata,
        string displayName,
        string tag)
    {
        Id = id;
        Status = status;
        Edges = edges;
        Nodes = nodes;
        ChiefApproval = chiefApproval;
        FrontMetadata = frontMetadata;
        DisplayName = displayName;
        Tag = tag;
    }

    public Id<ApprovalGraph> Id { get; }
    public ApprovalGraphStatus Status { get; }
    public ApprovalGraphEdge[] Edges { get; }
    public ApprovalGraphNode[] Nodes { get; }
    public ChiefApprovalStage ChiefApproval { get; }
    public Metadata<Front> FrontMetadata { get; }
    public string DisplayName { get; }
    public string Tag { get; }

    public override string ToString()
    {
        string tag = string.IsNullOrWhiteSpace(Tag) ? string.Empty : $", Tag: {Tag}";

        return $"{{ Name: {DisplayName}{tag}, Id: {Id} }}";
    }
}
