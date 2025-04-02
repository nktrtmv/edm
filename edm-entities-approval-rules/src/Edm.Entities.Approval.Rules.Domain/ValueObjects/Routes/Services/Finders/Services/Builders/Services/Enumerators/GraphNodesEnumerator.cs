using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Ends;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Starts;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders.Services.Builders.Services.Enumerators;

internal sealed class GraphNodesEnumerator
{
    internal GraphNodesEnumerator(ApprovalGraph graph, Entity entity)
    {
        Graph = graph;
        Entity = entity;
    }

    private ApprovalGraph Graph { get; }
    private Entity Entity { get; }

    public IEnumerable<ApprovalGraphNode> Enumerate()
    {
        ApprovalGraphNode start = GetStart();

        ApprovalGraphNode end = GetEnd();

        for (ApprovalGraphNode node = start; node != end; node = GetNext(node))
        {
            yield return node;
        }
    }

    private ApprovalGraphNode GetStart()
    {
        ApprovalGraphStartNode[] nodes = Graph.Nodes.OfType<ApprovalGraphStartNode>().ToArray();

        if (nodes.Length != 1)
        {
            throw new ApplicationException($"There should be exactly 1 start node but found {nodes.Length} start nodes.");
        }

        ApprovalGraphStartNode result = nodes.Single();

        return result;
    }

    private ApprovalGraphNode GetEnd()
    {
        ApprovalGraphEndNode[] nodes = Graph.Nodes.OfType<ApprovalGraphEndNode>().ToArray();

        if (nodes.Length != 1)
        {
            throw new ApplicationException($"There should be exactly 1 end node but found {nodes.Length} end nodes.");
        }

        ApprovalGraphEndNode result = nodes.Single();

        return result;
    }

    private ApprovalGraphNode GetNext(ApprovalGraphNode node)
    {
        ApprovalGraphEdge[] edges = Graph.Edges
            .Where(x => x.FromNodeId == node.Id && x.Condition.IsMet(Entity))
            .ToArray();

        if (edges.Length != 1)
        {
            throw new ApplicationException($"After applying conditions there should be exactly 1 outgoing edge from node ({node}) but found {edges.Length} edges.");
        }

        Id<ApprovalGraphNode> nodeId = edges.Single().ToNodeId;

        ApprovalGraphNode result = Graph.Nodes.Single(x => x.Id == nodeId);

        return result;
    }
}
