using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.Search.Rules;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.Search;

internal static class SearchApprovalRulesQueryResponseInternalConverter
{
    internal static SearchApprovalRulesQueryResponse ToDto(SearchApprovalRulesQueryResponseInternal response)
    {
        SearchApprovalRulesQueryResponseApprovalRule[] rules =
            response.Rules.Select(SearchApprovalRulesQueryResponseApprovalRuleInternalConverter.ToDto).ToArray();

        var result = new SearchApprovalRulesQueryResponse
        {
            Rules = { rules }
        };

        return result;
    }
}
