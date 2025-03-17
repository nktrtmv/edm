using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Statuses;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Validators;

internal static class ApprovalRuleHasAnyActiveGraphValidator
{
    internal static void Validate(ApprovalRule rule)
    {
        ApprovalGraph[] activeGraphs = rule.Graphs
            .Where(g => g.Status == ApprovalGraphStatus.Active)
            .ToArray();

        if (activeGraphs.Length == 0)
        {
            throw new ApplicationException(
                $"""
                No active graphs are found.
                Rule: {rule}
                """);
        }
    }
}
