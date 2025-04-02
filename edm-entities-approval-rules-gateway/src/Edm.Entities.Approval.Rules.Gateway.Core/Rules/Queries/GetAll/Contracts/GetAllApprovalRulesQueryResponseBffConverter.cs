using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts.Rules;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts;

internal static class GetAllApprovalRulesQueryResponseBffConverter
{
    internal static GetAllApprovalRulesQueryResponseBff FromDto(GetAllApprovalRulesQueryResponse response)
    {
        GetAllApprovalRulesQueryResponseApprovalRuleBff[] rules =
            response.Rules.Select(GetAllApprovalRulesQueryResponseApprovalRuleBffConverter.FromDto).ToArray();

        var result = new GetAllApprovalRulesQueryResponseBff
        {
            Rules = rules
        };

        return result;
    }
}
