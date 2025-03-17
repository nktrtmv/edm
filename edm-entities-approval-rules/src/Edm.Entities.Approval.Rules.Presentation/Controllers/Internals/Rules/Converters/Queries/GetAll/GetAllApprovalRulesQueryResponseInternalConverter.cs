using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetAll.Rules;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetAll;

internal static class GetAllApprovalRulesQueryResponseInternalConverter
{
    internal static GetAllApprovalRulesQueryResponse ToDto(GetAllApprovalRulesQueryResponseInternal response)
    {
        GetAllApprovalRulesQueryResponseApprovalRule[] rules =
            response.Rules.Select(GetAllApprovalRulesQueryResponseApprovalRuleInternalConverter.ToDto).ToArray();

        var result = new GetAllApprovalRulesQueryResponse
        {
            Rules = { rules }
        };

        return result;
    }
}
