using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.Unary;

public sealed class EntityLogicalUnaryConditionBff : EntityConditionBff
{
    public required EntityConditionOperatorBff Operator { get; init; }
    public required EntityConditionBff InnerCondition { get; init; }
}
