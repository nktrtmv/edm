using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetVersions.Contracts.Rules;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetVersions.Contracts;

internal static class GetVersionsApprovalRulesQueryResponseBffConverter
{
    internal static GetVersionsApprovalRulesQueryResponseBff FromDto(
        GetVersionsApprovalRulesQueryResponse response,
        EnrichersContext context)
    {
        GetVersionsApprovalRulesQueryResponseApprovalRuleBff[] rules =
            response.Rules.Select(r => GetVersionsApprovalRulesQueryResponseApprovalRuleBffConverter.FromDto(r, context)).ToArray();

        var result = new GetVersionsApprovalRulesQueryResponseBff
        {
            Rules = rules
        };

        return result;
    }
}
