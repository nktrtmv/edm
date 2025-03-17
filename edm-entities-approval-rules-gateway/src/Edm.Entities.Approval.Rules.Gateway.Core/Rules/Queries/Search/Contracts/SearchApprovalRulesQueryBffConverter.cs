using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts.Filters;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts;

internal static class SearchApprovalRulesQueryBffConverter
{
    internal static SearchApprovalRulesQuery ToDto(SearchApprovalRulesQueryBff query)
    {
        SearchApprovalRulesQueryFilter[] filters = query.Filters.Select(SearchApprovalRulesQueryFilterBffConverter.ToDto).ToArray();

        var result = new SearchApprovalRulesQuery
        {
            DomainId = query.DomainId,
            IsActiveRequired = query.IsActiveRequired,
            Filters = { filters }
        };

        return result;
    }
}
