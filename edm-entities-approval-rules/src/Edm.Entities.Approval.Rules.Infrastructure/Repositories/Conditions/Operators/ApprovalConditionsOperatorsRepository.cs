using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Conditions.Operators;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Conditions.Operators.Providers.Attributes;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Conditions.Operators.Providers.Logicals;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Conditions.Operators;

internal sealed class ApprovalConditionsOperatorsRepository : IApprovalConditionsOperatorsRepository
{
    private static readonly EntityConditionOperator[] LogicalOperators =
        EntityLogicalConditionOperatorsProvider.Get();

    private static readonly Dictionary<Type, EntityAttributeValueConditionOperator[]> AttributesOperators =
        EntityAttributeValueConditionOperatorsProvider.Get();

    public async Task<EntityConditionOperator[]> GetLogicalOperators(CancellationToken cancellationToken)
    {
        EntityConditionOperator[] result = await Task.FromResult(LogicalOperators);

        return result;
    }

    public async Task<Dictionary<Type, EntityAttributeValueConditionOperator[]>> GetAttributesOperators(CancellationToken cancellationToken)
    {
        Dictionary<Type, EntityAttributeValueConditionOperator[]> result = await Task.FromResult(AttributesOperators);

        return result;
    }
}
