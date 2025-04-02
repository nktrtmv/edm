using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.AttributesValues.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes;

namespace Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetAttributesOperators.Contracts.AttributesOperators;

internal static class GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsInternalConverter
{
    internal static GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsInternal FromDomain(
        EntityTypeAttribute attribute,
        Dictionary<Type, EntityAttributeValueConditionOperator[]> operators)
    {
        EntityAttributeValueConditionOperator[] attributeOperators = operators[attribute.GetType()];

        EntityTypeAttributeInternal attributeInternal =
            EntityTypeAttributeInternalFromDomainConverter.FromDomain(attribute);

        EntityConditionOperatorInternal[] attributeOperatorsInternal =
            attributeOperators.Select(EntityAttributeValueConditionOperatorInternalConverter.FromDomain).ToArray();

        var result = new GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsInternal(attributeInternal, attributeOperatorsInternal);

        return result;
    }
}
