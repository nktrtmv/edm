using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetLogicalOperators.Contracts;

internal static class GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseBffConverter
{
    internal static GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseBff FromDto(GetLogicalOperatorsApprovalConditionsOperatorsQueryResponse response)
    {
        EntityConditionOperatorBff[] operators =
            response.Operators.Select(EntityConditionOperatorBffConverter.FromDto).ToArray();

        var result = new GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseBff
        {
            Operators = operators
        };

        return result;
    }
}
