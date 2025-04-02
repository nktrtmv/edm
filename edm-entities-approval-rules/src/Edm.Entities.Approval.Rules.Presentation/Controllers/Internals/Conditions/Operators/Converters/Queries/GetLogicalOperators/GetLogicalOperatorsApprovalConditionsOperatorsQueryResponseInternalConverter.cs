using Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetLogicalOperators.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Naries.Operators;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Conditions.Operators.Converters.Queries.GetLogicalOperators;

internal static class GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseInternalConverter
{
    internal static GetLogicalOperatorsApprovalConditionsOperatorsQueryResponse ToDto(GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseInternal response)
    {
        EntityConditionOperatorDto[] operators =
            response.Operators.Select(EntityConditionOperatorInternalConverter.ToDto).ToArray();

        var result = new GetLogicalOperatorsApprovalConditionsOperatorsQueryResponse
        {
            Operators = { operators }
        };

        return result;
    }
}
