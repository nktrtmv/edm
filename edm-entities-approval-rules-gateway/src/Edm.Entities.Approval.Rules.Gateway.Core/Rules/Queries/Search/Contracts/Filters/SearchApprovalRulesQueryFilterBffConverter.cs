using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts.Filters.Inheritors;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts.Filters;

internal static class SearchApprovalRulesQueryFilterBffConverter
{
    internal static SearchApprovalRulesQueryFilter ToDto(SearchApprovalRulesQueryFilterBff filter)
    {
        var result = filter switch
        {
            SearchApprovalRulesQueryFilterByPersonInRolesBff byPersonInRoles
                => SearchApprovalRulesQueryFilterByPersonInRolesBffConverter.ToDto(byPersonInRoles),

            _ => throw new ArgumentTypeOutOfRangeException(filter)
        };

        return result;
    }
}
