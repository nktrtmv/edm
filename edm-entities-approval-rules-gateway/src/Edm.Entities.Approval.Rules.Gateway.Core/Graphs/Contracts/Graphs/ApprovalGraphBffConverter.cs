using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.ChiefApprovals;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Edges;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Statuses;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs;

internal static class ApprovalGraphBffConverter
{
    internal static ApprovalGraphBff FromDto(ApprovalGraphDto graph, ApprovalEnrichersContext context)
    {
        var status = ApprovalGraphStatusBffConverter.FromDto(graph.Status);

        ApprovalGraphEdgeBff[] edges = graph.Edges.Select(edge => ApprovalGraphEdgeBffConverter.FromDto(edge, context)).ToArray();

        ApprovalGraphNodeBff[] nodes = graph.Nodes.Select(x => ApprovalGraphNodeBffConverter.FromDto(x, context)).ToArray();

        var chiefApproval = ChiefApprovalStageBffConverter.FromDto(graph.ChiefApproval, context);

        var result = new ApprovalGraphBff
        {
            Id = graph.Id,
            Status = status,
            Edges = edges,
            Nodes = nodes,
            ChiefApproval = chiefApproval,
            FrontMetadata = graph.FrontMetadata,
            DisplayName = graph.DisplayName,
            Tag = graph.Tag
        };

        return result;
    }

    internal static ApprovalGraphDto ToDto(ApprovalGraphBff graph)
    {
        var status = ApprovalGraphStatusBffConverter.ToDto(graph.Status);

        ApprovalGraphEdgeDto[] edges = graph.Edges.Select(ApprovalGraphEdgeBffConverter.ToDto).ToArray();

        ApprovalGraphNodeDto[] nodes = graph.Nodes.Select(ApprovalGraphNodeBffConverter.ToDto).ToArray();

        var chiefApproval = ChiefApprovalStageBffConverter.ToDto(graph.ChiefApproval);

        var result = new ApprovalGraphDto
        {
            Id = graph.Id,
            Status = status,
            DisplayName = graph.DisplayName,
            Edges = { edges },
            Nodes = { nodes },
            ChiefApproval = chiefApproval,
            FrontMetadata = graph.FrontMetadata,
            Tag = graph.Tag
        };

        return result;
    }
}
