using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.FiltersAppliers.Filters.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Filters.Inheritors;

internal static class SearchApprovalRulesQueryFilterByPersonInGroupsInternalConverter
{
    internal static SearchApprovalRulesQueryFilterByPersonInGroups ToDomain(SearchApprovalRulesQueryFilterByPersonInGroupsInternal filter)
    {
        Id<User> personId = IdConverterFrom<User>.From(filter.PersonId);

        var result = new SearchApprovalRulesQueryFilterByPersonInGroups(personId);

        return result;
    }
}
