using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.ChiefApprovals;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Edges;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Markers;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Statuses;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Markers;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.ChiefApprovals;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Statuses;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;

internal static class ApprovalGraphInternalConverter
{
    internal static ApprovalGraphInternal FromDomain(ApprovalGraph graph)
    {
        Id<ApprovalGraphInternal> id = IdConverterFrom<ApprovalGraphInternal>.From(graph.Id);

        ApprovalGraphStatusInternal status = ApprovalGraphStatusInternalConverter.FromDomain(graph.Status);

        ApprovalGraphEdgeInternal[] edges = graph.Edges.Select(ApprovalGraphEdgeInternalConverter.FromDomain).ToArray();

        ApprovalGraphNodeInternal[] nodes = graph.Nodes.Select(ApprovalGraphNodeInternalConverter.FromDomain).ToArray();

        ChiefApprovalStageInternal chiefApproval = ChiefApprovalStageInternalConverter.FromDomain(graph.ChiefApproval);

        Metadata<FrontInternal> frontMetadata = MetadataConverterFrom<FrontInternal>.From(graph.FrontMetadata);

        var result = new ApprovalGraphInternal(
            id,
            status,
            edges,
            nodes,
            chiefApproval,
            frontMetadata,
            graph.DisplayName,
            graph.Tag);

        return result;
    }

    internal static ApprovalGraph ToDomain(ApprovalGraphInternal graph)
    {
        Id<ApprovalGraph> id = IdConverterFrom<ApprovalGraph>.From(graph.Id);

        ApprovalGraphStatus status = ApprovalGraphStatusInternalConverter.ToDomain(graph.Status);

        ApprovalGraphEdge[] edges = graph.Edges.Select(ApprovalGraphEdgeInternalConverter.ToDomain).ToArray();

        ApprovalGraphNode[] nodes = graph.Nodes.Select(ApprovalGraphNodeInternalConverter.ToDomain).ToArray();

        ChiefApprovalStage chiefApproval = ChiefApprovalStageInternalConverter.ToDomain(graph.ChiefApproval);

        Metadata<Front> frontMetadata = MetadataConverterFrom<Front>.From(graph.FrontMetadata);

        var result = new ApprovalGraph(
            id,
            status,
            edges,
            nodes,
            chiefApproval,
            frontMetadata,
            graph.DisplayName,
            graph.Tag);

        return result;
    }
}
