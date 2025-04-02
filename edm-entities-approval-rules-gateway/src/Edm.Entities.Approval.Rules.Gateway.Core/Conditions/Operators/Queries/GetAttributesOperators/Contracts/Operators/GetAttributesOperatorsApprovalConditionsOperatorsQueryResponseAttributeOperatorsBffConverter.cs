using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetAttributesOperators.Contracts.Operators;

internal static class GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsBffConverter
{
    internal static GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsBff FromDto(
        GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperators attributeOperators)
    {
        EntityConditionOperatorBff[] operators =
            attributeOperators.Operators.Select(EntityConditionOperatorBffConverter.FromDto).ToArray();

        var attribute = EntityTypeAttributeBffConverter.FromDto(attributeOperators.Attribute);

        var result = new GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsBff
        {
            Attribute = attribute,
            Operators = operators
        };

        return result;
    }
}
