using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.ChiefApprovals;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Edges;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Markers;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Statuses;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.ChiefApprovals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.Edges;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.Nodes;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.Statuses;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs;

internal static class ApprovalGraphInternalConverter
{
    internal static ApprovalGraphDto ToDto(ApprovalGraphInternal graph)
    {
        var id = IdConverterTo.ToString(graph.Id);

        ApprovalGraphStatusDto status =
            ApprovalGraphStatusInternalConverter.ToDto(graph.Status);

        ApprovalGraphEdgeDto[] edges =
            graph.Edges.Select(ApprovalGraphEdgeInternalConverter.ToDto).ToArray();

        ApprovalGraphNodeDto[] nodes =
            graph.Nodes.Select(ApprovalGraphNodeInternalConverter.ToDto).ToArray();

        ChiefApprovalStageDto chiefApproval =
            ChiefApprovalStageInternalConverter.ToDto(graph.ChiefApproval);

        var frontMetadata = MetadataConverterTo.ToString(graph.FrontMetadata);

        var result = new ApprovalGraphDto
        {
            Id = id,
            Status = status,
            Edges = { edges },
            Nodes = { nodes },
            ChiefApproval = chiefApproval,
            FrontMetadata = frontMetadata,
            DisplayName = graph.DisplayName,
            Tag = graph.Tag
        };

        return result;
    }

    internal static ApprovalGraphInternal FromDto(ApprovalGraphDto graph)
    {
        Id<ApprovalGraphInternal> id =
            IdConverterFrom<ApprovalGraphInternal>.FromString(graph.Id);

        ApprovalGraphStatusInternal status =
            ApprovalGraphStatusInternalConverter.FromDto(graph.Status);

        ApprovalGraphEdgeInternal[] edges =
            graph.Edges.Select(ApprovalGraphEdgeInternalConverter.FromDto).ToArray();

        ApprovalGraphNodeInternal[] nodes =
            graph.Nodes.Select(ApprovalGraphNodeInternalConverter.FromDto).ToArray();

        ChiefApprovalStageInternal chiefApproval =
            ChiefApprovalStageInternalConverter.FromDto(graph.ChiefApproval);

        Metadata<FrontInternal> frontMetadata =
            MetadataConverterFrom<FrontInternal>.FromString(graph.FrontMetadata);

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
}
