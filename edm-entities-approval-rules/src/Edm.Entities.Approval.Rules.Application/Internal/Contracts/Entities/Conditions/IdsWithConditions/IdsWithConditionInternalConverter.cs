/*
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.ValueObjects.IdsWithConditions;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.IdsWithConditions;

internal static class IdsWithConditionInternalConverter<T>
{
    internal static IdsWithConditionInternal<T> FromDomain<TSource>(IdsWithCondition<TSource> elements)
    {
        EntityConditionInternal condition = EntityConditionInternalConverter.FromDomain(elements.Condition);

        Id<T>[] ids = elements.Ids.Select(IdConverterFrom<T>.From).ToArray();

        var result = new IdsWithConditionInternal<T>(condition, ids);

        return result;
    }

    internal static IdsWithCondition<T> ToDomain<TSource>(IdsWithConditionInternal<TSource> elements)
    {
        EntityCondition condition = EntityConditionInternalConverter.ToDomain(elements.Condition);

        Id<T>[] ids = elements.Ids.Select(IdConverterFrom<T>.From).ToArray();

        var result = new IdsWithCondition<T>(condition, ids);

        return result;
    }
}
*/


