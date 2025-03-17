using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Nones;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Collectors.EntitiesConditions;

public static class EntityAttributesValuesConditionsCollector
{
    public static IEnumerable<EntityAttributeValueCondition> Collect(params EntityCondition[] conditions)
    {
        foreach (EntityCondition condition in conditions)
        {
            if (condition is EntityNoneCondition)
            {
                continue;
            }

            if (condition is EntityAttributeValueCondition attributeValueCondition)
            {
                yield return attributeValueCondition;

                continue;
            }

            IEnumerable<EntityAttributeValueCondition> innerAttributesValuesConditions = condition switch
            {
                EntityLogicalUnaryCondition unary => Collect(unary.InnerCondition),
                EntityLogicalNaryCondition nary => Collect(nary.InnerConditions),
                _ => throw new ArgumentTypeOutOfRangeException(condition)
            };

            foreach (EntityAttributeValueCondition innerAttributeValueCondition in innerAttributesValuesConditions)
            {
                yield return innerAttributeValueCondition;
            }
        }
    }
}
