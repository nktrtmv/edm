using Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetAttributesOperators.Contracts.Operators;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetAttributesOperators.Contracts;

internal static class GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseBffConverter
{
    internal static GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseBff FromDto(GetAttributesOperatorsApprovalConditionsOperatorsQueryResponse response)
    {
        GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsBff[] attributeOperators =
            response.AttributesOperators.Select(GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsBffConverter.FromDto).ToArray();

        var result = new GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseBff
        {
            AttributesOperators = attributeOperators
        };

        return result;
    }
}
