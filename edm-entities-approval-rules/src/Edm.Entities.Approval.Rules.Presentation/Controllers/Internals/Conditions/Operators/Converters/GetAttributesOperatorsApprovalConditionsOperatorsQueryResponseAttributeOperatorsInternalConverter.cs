using Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetAttributesOperators.Contracts.AttributesOperators;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Naries.Operators;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Attributes;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Conditions.Operators.Converters;

internal static class GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsInternalConverter
{
    internal static GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperators ToDto(
        GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsInternal attributeOperators)
    {
        EntityTypeAttributeDto attribute = EntityTypeAttributeInternalToDtoConverter.ToDto(attributeOperators.Attribute);

        EntityConditionOperatorDto[] operators = attributeOperators.Operators.Select(EntityConditionOperatorInternalConverter.ToDto).ToArray();

        var result = new GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperators
        {
            Attribute = attribute,
            Operators = { operators }
        };

        return result;
    }
}
