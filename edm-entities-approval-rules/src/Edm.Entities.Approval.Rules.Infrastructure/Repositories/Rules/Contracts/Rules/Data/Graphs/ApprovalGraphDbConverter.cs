using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Markers;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.ChiefApprovals;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.ChiefApprovals.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Statuses;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Converters;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.ChiefApprovals;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.Edges;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.Nodes;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.Statuses;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs;

internal static class ApprovalGraphDbConverter
{
    internal static ApprovalGraphDb FromDomain(ApprovalGraph graph)
    {
        var id = IdConverterTo.ToString(graph.Id);

        ApprovalGraphStatusDb status =
            ApprovalGraphStatusDbConverter.FromDomain(graph.Status);

        ApprovalGraphEdgeDb[] edges =
            graph.Edges.Select(ApprovalGraphEdgeDbConverter.FromDomain).ToArray();

        ApprovalGraphNodeDb[] nodes =
            graph.Nodes.Select(ApprovalGraphNodeDbConverter.FromDomain).ToArray();

        ChiefApprovalStageDb chiefApproval =
            ChiefApprovalStageDbConverter.FromDomain(graph.ChiefApproval);

        var frontMetadata = MetadataConverterTo.ToString(graph.FrontMetadata);

        var result = new ApprovalGraphDb
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

    internal static ApprovalGraph ToDomain(ApprovalGraphDb graph)
    {
        Id<ApprovalGraph> id =
            IdConverterFrom<ApprovalGraph>.FromString(graph.Id);

        ApprovalGraphStatus status =
            ApprovalGraphStatusDbConverter.ToDomain(graph.Status);

        ApprovalGraphEdge[] edges =
            graph.Edges.Select(ApprovalGraphEdgeDbConverter.ToDomain).ToArray();

        ApprovalGraphNode[] nodes =
            graph.Nodes.Select(ApprovalGraphNodeDbConverter.ToDomain).ToArray();

        // TODO: Delete NullableConverter: Backward compatability
        ChiefApprovalStage chiefApproval =
            NullableConverter.Convert(graph.ChiefApproval, ChiefApprovalStageDbConverter.ToDomain)
            ?? ChiefApprovalStageFactory.CreateNew();

        Metadata<Front> frontMetadata =
            MetadataConverterFrom<Front>.FromString(graph.FrontMetadata);

        ApprovalGraph result = ApprovalGraphFactory.CreateFromDb(
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
