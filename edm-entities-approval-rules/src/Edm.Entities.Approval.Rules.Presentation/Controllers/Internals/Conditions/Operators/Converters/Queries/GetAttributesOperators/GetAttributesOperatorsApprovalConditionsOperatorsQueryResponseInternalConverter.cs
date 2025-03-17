using Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetAttributesOperators.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Conditions.Operators.Converters.Queries.GetAttributesOperators;

internal static class GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternalConverter
{
    internal static GetAttributesOperatorsApprovalConditionsOperatorsQueryResponse ToDto(GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternal response)
    {
        GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperators[] attributesOperators =
            response.AttributesOperators.Select(GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsInternalConverter.ToDto).ToArray();

        var result = new GetAttributesOperatorsApprovalConditionsOperatorsQueryResponse
        {
            AttributesOperators = { attributesOperators }
        };

        return result;
    }
}
