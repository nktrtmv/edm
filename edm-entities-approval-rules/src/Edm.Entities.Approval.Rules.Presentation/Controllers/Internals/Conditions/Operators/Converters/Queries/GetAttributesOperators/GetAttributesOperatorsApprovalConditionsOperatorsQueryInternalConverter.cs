using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetAttributesOperators.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Conditions.Operators.Converters.Queries.GetAttributesOperators;

internal static class GetAttributesOperatorsApprovalConditionsOperatorsQueryInternalConverter
{
    internal static GetAttributesOperatorsApprovalConditionsOperatorsQueryInternal FromDto(GetAttributesOperatorsApprovalConditionsOperatorsQuery query)
    {
        ApprovalRuleKeyInternal approvalRuleKey = ApprovalRuleKeyInternalConverter.FromDto(query.ApprovalRuleKey);

        var result = new GetAttributesOperatorsApprovalConditionsOperatorsQueryInternal(approvalRuleKey);

        return result;
    }
}
