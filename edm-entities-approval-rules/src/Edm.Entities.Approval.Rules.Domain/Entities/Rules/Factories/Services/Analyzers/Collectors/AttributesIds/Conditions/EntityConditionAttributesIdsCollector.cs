using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Nones;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Conditions;

internal static class EntityConditionAttributesIdsCollector
{
    internal static void Collect(HashSet<int> attributesIds, EntityCondition condition)
    {
        _ = condition switch
        {
            EntityAttributeValueCondition c => Collect(attributesIds, c.AttributeValue),
            EntityLogicalNaryCondition c => Collect(attributesIds, c.InnerConditions),
            EntityLogicalUnaryCondition c => Collect(attributesIds, new[] { c.InnerCondition }),
            EntityNoneCondition => default,
            _ => throw new ArgumentTypeOutOfRangeException(condition)
        };
    }

    private static None Collect(HashSet<int> attributesIds, EntityAttributeValue attributeValue)
    {
        attributesIds.Add(attributeValue.Id);

        return default;
    }

    private static None Collect(HashSet<int> attributesIds, params EntityCondition[] conditions)
    {
        foreach (EntityCondition condition in conditions)
        {
            Collect(attributesIds, condition);
        }

        return default;
    }
}
