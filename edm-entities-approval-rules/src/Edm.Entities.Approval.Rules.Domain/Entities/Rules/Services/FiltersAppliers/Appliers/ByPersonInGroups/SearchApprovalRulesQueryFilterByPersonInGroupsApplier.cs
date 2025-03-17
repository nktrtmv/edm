using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Detectors.ContainsPerson;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.FiltersAppliers.Filters.Inheritors;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.FiltersAppliers.Appliers.ByPersonInGroups;

internal static class SearchApprovalRulesQueryFilterByPersonInGroupsApplier
{
    public static ApprovalRule[] ApplyFilter(ApprovalRule[] rules, SearchApprovalRulesQueryFilterByPersonInGroups filter)
    {
        ApprovalRule[] result = rules
            .Where(r => RuleContainsPersonApprovalRuleDetector.Contains(r, filter.PersonId))
            .ToArray();

        return result;
    }
}
