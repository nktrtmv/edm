using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.Services.Validators.GroupIsUsedInGraphs;

internal static class GroupIsUsedInGraphsApprovalGroupValidator
{
    internal static void Validate(ApprovalRule rule, Id<ApprovalGroup> groupId)
    {
        ApprovalGraph[] graphsWithGroupUsage = rule.Graphs
            .Where(g => IsGroupUsed(g, groupId))
            .ToArray();

        if (graphsWithGroupUsage.Length == 0)
        {
            return;
        }

        string[] graphsNames = graphsWithGroupUsage
            .Select(g => g.DisplayName)
            .ToArray();

        string graphs = string.Join(", ", graphsNames);

        throw new ApplicationException(
            $"""
             The group is in use.
             GroupId: {groupId}
             GraphsWithGroupUsage: {graphs}
             """);
    }

    private static bool IsGroupUsed(ApprovalGraph graph, Id<ApprovalGroup> groupId)
    {
        bool result = graph.Nodes
            .OfType<ApprovalGraphStageNode>()
            .SelectMany(n => n.Sets)
            .SelectMany(g => g.GroupsIds)
            .Any(id => id == groupId);

        return result;
    }
}
