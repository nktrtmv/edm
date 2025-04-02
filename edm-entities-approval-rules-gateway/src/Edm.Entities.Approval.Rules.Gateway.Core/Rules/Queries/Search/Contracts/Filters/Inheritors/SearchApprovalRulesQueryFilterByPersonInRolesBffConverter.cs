using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts.Filters.Inheritors;

internal static class SearchApprovalRulesQueryFilterByPersonInRolesBffConverter
{
    internal static SearchApprovalRulesQueryFilter ToDto(SearchApprovalRulesQueryFilterByPersonInRolesBff filter)
    {
        var byPersonInGroups = new SearchApprovalRulesQueryFilterByPersonInGroups
        {
            PersonId = filter.PersonId
        };

        var result = new SearchApprovalRulesQueryFilter
        {
            ByPersonInGroups = byPersonInGroups
        };

        return result;
    }
}
