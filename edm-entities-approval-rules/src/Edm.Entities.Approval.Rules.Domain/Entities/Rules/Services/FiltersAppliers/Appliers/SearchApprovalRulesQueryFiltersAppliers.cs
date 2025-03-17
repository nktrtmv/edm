using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.FiltersAppliers.Appliers.ByPersonInGroups;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.FiltersAppliers.Filters;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.FiltersAppliers.Filters.Inheritors;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.FiltersAppliers.Appliers;

public static class SearchApprovalRulesQueryFiltersAppliers
{
    public static ApprovalRule[] Apply(ApprovalRule[] rules, SearchApprovalRulesQueryFilter[] filters)
    {
        ApprovalRule[] result = filters.Aggregate(rules, ApplyFilter);

        return result;
    }

    private static ApprovalRule[] ApplyFilter(ApprovalRule[] rules, SearchApprovalRulesQueryFilter filter)
    {
        ApprovalRule[] result = filter switch
        {
            SearchApprovalRulesQueryFilterByPersonInGroups filterByPersonInGroups =>
                SearchApprovalRulesQueryFilterByPersonInGroupsApplier.ApplyFilter(rules, filterByPersonInGroups),

            _ => throw new ArgumentTypeOutOfRangeException(filter)
        };

        return result;
    }
}
