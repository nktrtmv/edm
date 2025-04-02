using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.Nary;

public sealed class EntityLogicalNaryConditionBff : EntityConditionBff
{
    public required EntityConditionOperatorBff Operator { get; init; }
    public required EntityConditionBff[] InnerConditions { get; init; }
}
