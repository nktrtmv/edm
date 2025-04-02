using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Statuses;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Validators;

public static class ThereAreActiveGraphsForAllTagsApprovalRuleValidator
{
    public static void Validate(ApprovalRule rule, string[] graphsTags)
    {
        Dictionary<string, ApprovalGraph> activeGraphsByTag =
            rule.Graphs.Where(g => g.Status == ApprovalGraphStatus.Active).ToDictionary(g => g.Tag);

        string[] graphsTagsWithoutActiveGraphs =
            graphsTags.Where(t => !activeGraphsByTag.ContainsKey(t)).ToArray();

        if (!graphsTagsWithoutActiveGraphs.Any())
        {
            return;
        }

        ThrowNoActiveGraphsAreFoundException(graphsTagsWithoutActiveGraphs);
    }

    private static void ThrowNoActiveGraphsAreFoundException(string[] graphsTagsWithoutActiveGraphs)
    {
        string graphsTagsWithoutActiveGraphsString = string.Join(", ", graphsTagsWithoutActiveGraphs);

        throw new ApplicationException($"No active graphs are found.\nTags: [{graphsTagsWithoutActiveGraphsString}]");
    }
}
