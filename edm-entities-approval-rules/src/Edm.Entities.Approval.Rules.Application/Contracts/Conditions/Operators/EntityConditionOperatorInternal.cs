using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators.Types;

namespace Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;

public sealed class EntityConditionOperatorInternal
{
    internal EntityConditionOperatorInternal(EntityConditionOperatorTypeInternal type, string displayName)
    {
        Type = type;
        DisplayName = displayName;
    }

    public EntityConditionOperatorTypeInternal Type { get; }
    public string DisplayName { get; }
}
