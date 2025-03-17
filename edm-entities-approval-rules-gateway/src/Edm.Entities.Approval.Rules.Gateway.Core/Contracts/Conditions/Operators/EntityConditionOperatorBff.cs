namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;

public sealed class EntityConditionOperatorBff
{
    public required EntityConditionOperatorKindBff Kind { get; init; }
    public required EntityConditionOperatorTypeBff Type { get; init; }
    public required string DisplayName { get; init; }
}
