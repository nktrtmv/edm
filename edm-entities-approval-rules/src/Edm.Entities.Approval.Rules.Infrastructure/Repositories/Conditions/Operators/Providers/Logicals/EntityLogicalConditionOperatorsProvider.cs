using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Conditions.Operators.Providers.Logicals.Naries;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Conditions.Operators.Providers.Logicals.Unaries;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Conditions.Operators.Providers.Logicals;

internal static class EntityLogicalConditionOperatorsProvider
{
    private static readonly EntityConditionOperator[] Operators =
        Array.Empty<EntityConditionOperator>()
            .Concat(EntityNaryLogicalConditionOperatorsProvider.Get())
            .Concat(EntityUnaryLogicalConditionOperatorsProvider.Get())
            .ToArray();

    internal static EntityConditionOperator[] Get()
    {
        return Operators;
    }
}
