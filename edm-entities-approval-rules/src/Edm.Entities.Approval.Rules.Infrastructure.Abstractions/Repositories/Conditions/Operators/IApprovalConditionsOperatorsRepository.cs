using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.ValueObjects.Operators;

namespace Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Conditions.Operators;

public interface IApprovalConditionsOperatorsRepository
{
    Task<EntityConditionOperator[]> GetLogicalOperators(CancellationToken cancellationToken);

    Task<Dictionary<Type, EntityAttributeValueConditionOperator[]>> GetAttributesOperators(CancellationToken cancellationToken);
}
