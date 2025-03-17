using Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetAttributesOperators.Contracts.AttributesOperators;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators;

namespace Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetAttributesOperators.Contracts;

internal static class GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternalConverter
{
    internal static GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternal FromDomain(
        Dictionary<Type, EntityAttributeValueConditionOperator[]> attributesOperators,
        ApprovalRule rule)
    {
        GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsInternal[] attributesOperatorsInternal = rule.EntityType.Attributes
            .Select(a => GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsInternalConverter.FromDomain(a, attributesOperators))
            .ToArray();

        var result = new GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternal(attributesOperatorsInternal);

        return result;
    }
}
