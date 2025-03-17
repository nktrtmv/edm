using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.IdsWithConditions;

public sealed class IdsWithConditionInternal<T>
{
    public IdsWithConditionInternal(EntityConditionInternal condition, Id<T>[] ids)
    {
        Ids = ids;
        Condition = condition;
    }

    public EntityConditionInternal Condition { get; }
    public Id<T>[] Ids { get; }
}
