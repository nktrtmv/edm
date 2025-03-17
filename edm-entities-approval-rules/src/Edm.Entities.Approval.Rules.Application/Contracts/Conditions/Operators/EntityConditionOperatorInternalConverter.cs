using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.AttributesValues.Operators;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Naries.Operators;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Unaries.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Equals;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Greater;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.GreaterOrEquals;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Less;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.LessOrEquals;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators.Inheritors.Ands;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators.Inheritors.Ors;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries.ValueObjects.Operators.Inheritors.Nots;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;

internal static class EntityConditionOperatorInternalConverter
{
    internal static EntityConditionOperatorInternal FromDomain(EntityConditionOperator @operator)
    {
        EntityConditionOperatorInternal result = @operator switch
        {
            EntityAttributeValueConditionEqualOperator => EntityAttributeValueConditionOperatorInternal.Equal,
            EntityAttributeValueConditionGreaterOperator => EntityAttributeValueConditionOperatorInternal.Greater,
            EntityAttributeValueConditionGreaterOrEqualOperator => EntityAttributeValueConditionOperatorInternal.GreaterOrEqual,
            EntityAttributeValueConditionLessOperator => EntityAttributeValueConditionOperatorInternal.Less,
            EntityAttributeValueConditionLessOrEqualOperator => EntityAttributeValueConditionOperatorInternal.LessOrEqual,

            EntityLogicalNaryConditionAndOperator => EntityLogicalNaryConditionOperatorInternal.And,
            EntityLogicalNaryConditionOrOperator => EntityLogicalNaryConditionOperatorInternal.Or,

            EntityLogicalUnaryConditionNotOperator => EntityLogicalUnaryConditionOperatorInternal.Not,

            _ => throw new ArgumentTypeOutOfRangeException(@operator)
        };

        return result;
    }
}
