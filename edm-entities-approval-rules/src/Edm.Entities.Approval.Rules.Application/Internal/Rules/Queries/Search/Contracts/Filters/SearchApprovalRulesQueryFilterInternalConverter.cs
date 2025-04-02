using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Filters.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.FiltersAppliers.Filters;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Filters;

internal static class SearchApprovalRulesQueryFilterInternalConverter
{
    internal static SearchApprovalRulesQueryFilter ToDomain(SearchApprovalRulesQueryFilterInternal filter)
    {
        SearchApprovalRulesQueryFilter result = filter switch
        {
            SearchApprovalRulesQueryFilterByPersonInGroupsInternal filterByPersonInGroups =>
                SearchApprovalRulesQueryFilterByPersonInGroupsInternalConverter.ToDomain(filterByPersonInGroups),

            _ => throw new ArgumentTypeOutOfRangeException(filter)
        };

        return result;
    }
}
