using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts.Rules;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts;

internal static class SearchApprovalRulesQueryResponseBffConverter
{
    internal static SearchApprovalRulesQueryResponseBff FromDto(SearchApprovalRulesQueryResponse response, EnrichersContext context)
    {
        SearchApprovalRulesQueryResponseApprovalRuleBff[] rules =
            response.Rules.Select(r => SearchApprovalRulesQueryResponseApprovalRuleBffConverter.FromDto(r, context)).ToArray();

        var result = new SearchApprovalRulesQueryResponseBff
        {
            Rules = rules
        };

        return result;
    }
}
