using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Filters;
using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.Search.Filters;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.Search;

internal static class SearchApprovalRulesQueryInternalConverter
{
    internal static SearchApprovalRulesQueryInternal FromDto(SearchApprovalRulesQuery query)
    {
        DomainId domainId = DomainId.Parse(query.DomainId);

        SearchApprovalRulesQueryFilterInternal[] filters =
            query.Filters.Select(SearchApprovalRulesQueryFilterInternalConverter.FromDto).ToArray();

        var result = new SearchApprovalRulesQueryInternal(domainId, query.IsActiveRequired, filters);

        return result;
    }
}
