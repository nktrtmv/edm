using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Filters;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Filters.Inheritors;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.Search.Filters;

internal static class SearchApprovalRulesQueryFilterInternalConverter
{
    internal static SearchApprovalRulesQueryFilterInternal FromDto(SearchApprovalRulesQueryFilter filter)
    {
        SearchApprovalRulesQueryFilterInternal result = filter.FilterCase switch
        {
            SearchApprovalRulesQueryFilter.FilterOneofCase.ByPersonInGroups => ToByPersonInGroups(filter.ByPersonInGroups),
            _ => throw new ArgumentTypeOutOfRangeException(filter.FilterCase)
        };

        return result;
    }

    private static SearchApprovalRulesQueryFilterByPersonInGroupsInternal ToByPersonInGroups(SearchApprovalRulesQueryFilterByPersonInGroups filter)
    {
        Id<UserInternal> personId = IdConverterFrom<UserInternal>.FromString(filter.PersonId);

        var result = new SearchApprovalRulesQueryFilterByPersonInGroupsInternal(personId);

        return result;
    }
}
