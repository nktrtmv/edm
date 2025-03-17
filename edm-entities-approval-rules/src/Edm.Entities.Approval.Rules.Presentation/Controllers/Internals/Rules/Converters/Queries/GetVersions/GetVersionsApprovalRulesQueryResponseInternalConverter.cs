using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetVersions.Rules;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetVersions;

internal static class GetVersionsApprovalRulesQueryResponseInternalConverter
{
    internal static GetVersionsApprovalRulesQueryResponse ToDto(GetVersionsApprovalRulesQueryResponseInternal response)
    {
        GetVersionsApprovalRulesQueryResponseApprovalRule[] rules =
            response.Rules.Select(GetVersionsApprovalRulesQueryResponseApprovalRuleInternalConverter.ToDto).ToArray();

        var result = new GetVersionsApprovalRulesQueryResponse
        {
            Rules = { rules }
        };

        return result;
    }
}
