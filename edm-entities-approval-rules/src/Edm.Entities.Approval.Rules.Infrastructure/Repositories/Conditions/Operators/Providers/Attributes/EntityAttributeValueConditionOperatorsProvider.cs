using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Equals;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Greater;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.GreaterOrEquals;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Less;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.LessOrEquals;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Date;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Number;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.String;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Conditions.Operators.Providers.Attributes;

internal static class EntityAttributeValueConditionOperatorsProvider
{
    private static readonly EntityAttributeValueConditionOperator[] EqualsOperators =
    {
        EntityAttributeValueConditionEqualOperator.Instance
    };

    private static readonly EntityAttributeValueConditionOperator[] EqualAndGreaterAndLessOperators =
    {
        EntityAttributeValueConditionEqualOperator.Instance,
        EntityAttributeValueConditionGreaterOperator.Instance,
        EntityAttributeValueConditionGreaterOrEqualOperator.Instance,
        EntityAttributeValueConditionLessOperator.Instance,
        EntityAttributeValueConditionLessOrEqualOperator.Instance
    };

    private static readonly Dictionary<Type, EntityAttributeValueConditionOperator[]> AttributesOperators =
        new Dictionary<Type, EntityAttributeValueConditionOperator[]>
        {
            { typeof(EntityTypeBooleanAttribute), EqualsOperators },
            { typeof(EntityTypeDateAttribute), EqualAndGreaterAndLessOperators },
            { typeof(EntityTypeNumberAttribute), EqualAndGreaterAndLessOperators },
            { typeof(EntityTypeReferenceAttribute), EqualsOperators },
            { typeof(EntityTypeStringAttribute), EqualAndGreaterAndLessOperators }
        };

    internal static Dictionary<Type, EntityAttributeValueConditionOperator[]> Get()
    {
        return AttributesOperators;
    }
}
