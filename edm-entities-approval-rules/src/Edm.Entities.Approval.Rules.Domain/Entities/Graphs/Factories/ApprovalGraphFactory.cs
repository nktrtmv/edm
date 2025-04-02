using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Markers;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.ChiefApprovals;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.ChiefApprovals.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Ends.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Starts.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Statuses;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Nones;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Factories;

public static class ApprovalGraphFactory
{
    public static ApprovalGraph CreateNew(string displayName)
    {
        var id = Id<ApprovalGraph>.CreateNew();

        ApprovalGraphNode from = ApprovalGraphStartNodeFactory.CreateNew();

        ApprovalGraphNode to = ApprovalGraphEndNodeFactory.CreateNew();

        ApprovalGraphNode[] nodes = { from, to };

        ApprovalGraphEdge edge = ApprovalGraphEdgeFactory.CreateNew(from.Id, to.Id, EntityNoneCondition.Instance);

        ApprovalGraphEdge[] edges = { edge };

        ChiefApprovalStage chiefApproval = ChiefApprovalStageFactory.CreateNew();

        var frontMetadata = Metadata<Front>.Empty;

        var tag = string.Empty;

        var result = new ApprovalGraph(id, ApprovalGraphStatus.Draft, edges, nodes, chiefApproval, frontMetadata, displayName, tag);

        return result;
    }

    public static ApprovalGraph CreateFromDb(
        Id<ApprovalGraph> id,
        ApprovalGraphStatus status,
        ApprovalGraphEdge[] edges,
        ApprovalGraphNode[] nodes,
        ChiefApprovalStage chiefApproval,
        Metadata<Front> frontMetadata,
        string displayName,
        string tag)
    {
        var result = new ApprovalGraph(id, status, edges, nodes, chiefApproval, frontMetadata, displayName, tag);

        return result;
    }
}
