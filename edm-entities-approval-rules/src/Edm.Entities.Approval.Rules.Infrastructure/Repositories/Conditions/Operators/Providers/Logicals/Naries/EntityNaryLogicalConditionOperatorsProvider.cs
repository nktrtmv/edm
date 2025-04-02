using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators.Inheritors.Ands;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators.Inheritors.Ors;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Conditions.Operators.Providers.Logicals.Naries;

internal static class EntityNaryLogicalConditionOperatorsProvider
{
    private static readonly EntityLogicalNaryConditionOperator[] Operators =
    {
        EntityLogicalNaryConditionAndOperator.Instance,
        EntityLogicalNaryConditionOrOperator.Instance
    };

    internal static EntityLogicalNaryConditionOperator[] Get()
    {
        return Operators;
    }
}
