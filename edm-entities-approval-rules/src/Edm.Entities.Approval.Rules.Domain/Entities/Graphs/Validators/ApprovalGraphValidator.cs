using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Validators.Validators.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Validators.Validators.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Validators.Validators.Routes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Ends;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Starts;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Validators;

internal static class ApprovalGraphValidator
{
    internal static void Validate(ApprovalGraph graph)
    {
        Dictionary<Id<ApprovalGraphNode>, ApprovalGraphNode> nodesById = graph.Nodes.ToDictionary(n => n.Id);

        GraphHasExactlyOneStartNodeValidator.Validate(graph.Nodes);
        AllEdgesHasCorrespondedNodesValidator.Validate(graph.Edges, nodesById);
        AllNodesAreUsedValidator.Validate(graph.Edges, nodesById.Keys);

        Dictionary<Id<ApprovalGraphNode>, ApprovalGraphEdge[]> edgesByFrom = graph.Edges.GroupBy(t => t.FromNodeId).ToDictionary(t => t.Key, t => t.ToArray());

        AllRoutesAreFinalizedByEndNodeAndGraphConnectivityValidator.Validate(edgesByFrom, nodesById);
        AllEdgesFromANodeWithMultipleOutgoingEdgesHaveConditionValidator.Validate(edgesByFrom);
        AllEdgesFromTheSameNodeHasNoDuplicateConditionsValidator.Validate(edgesByFrom);

        ApprovalGraphStartNode startNode = graph.Nodes.OfType<ApprovalGraphStartNode>().Single();

        NoEdgesLeadingToStartNodeValidator.Validate(graph.Edges, startNode);
        OnlyOneEdgeLeadingFromStartNodeValidator.Validate(graph.Edges, startNode);

        ApprovalGraphEndNode endNode = graph.Nodes.OfType<ApprovalGraphEndNode>().Single();

        NoEdgesLeadingFromEndNodeValidator.Validate(graph.Edges, endNode);
    }
}
