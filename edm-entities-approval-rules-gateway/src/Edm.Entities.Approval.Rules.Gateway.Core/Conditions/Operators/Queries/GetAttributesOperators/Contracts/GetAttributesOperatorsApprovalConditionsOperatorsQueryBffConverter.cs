using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetAttributesOperators.Contracts;

internal static class GetAttributesOperatorsApprovalConditionsOperatorsQueryBffConverter
{
    internal static GetAttributesOperatorsApprovalConditionsOperatorsQuery ToDto(GetAttributesOperatorsApprovalConditionsOperatorsQueryBff query)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.ToDto(query.ApprovalRuleKey);

        var result = new GetAttributesOperatorsApprovalConditionsOperatorsQuery
        {
            ApprovalRuleKey = approvalRuleKey
        };

        return result;
    }
}
