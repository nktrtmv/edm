using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries.ValueObjects.Operators.Inheritors.Nots;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Conditions.Operators.Providers.Logicals.Unaries;

internal static class EntityUnaryLogicalConditionOperatorsProvider
{
    private static readonly EntityLogicalUnaryConditionOperator[] Operators =
    {
        EntityLogicalUnaryConditionNotOperator.Instance
    };

    internal static EntityLogicalUnaryConditionOperator[] Get()
    {
        return Operators;
    }
}
