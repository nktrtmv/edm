namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;

public enum EntityConditionOperatorTypeBff
{
    None = 0,

    AttributeValueEqual = 101,
    AttributeValueGreater = 102,
    AttributeValueGreaterOrEqual = 105,
    AttributeValueLess = 103,
    AttributeValueLessOrEqual = 104,

    LogicalNaryAnd = 201,
    LogicalNaryOr = 202,

    LogicalUnaryNot = 301
}
