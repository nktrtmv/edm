namespace Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators.Types;

public enum EntityConditionOperatorTypeInternal
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
