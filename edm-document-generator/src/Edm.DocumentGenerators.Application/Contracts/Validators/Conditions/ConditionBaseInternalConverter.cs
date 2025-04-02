using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ForDocumentAttributesValues;
using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ForDocumentAttributesValues.ValueObjects;
using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ForDocumentAttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ForDocumentAttributesValues.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Contracts.Validators.Conditions;

internal static class ConditionBaseInternalConverter
{
    internal static ConditionBaseInternal FromDomain(ICondition condition)
    {
        ConditionDataInternal data = ConditionDataInternalConverter.FromDomain(condition.Data);

        ConditionBaseInternal result = condition switch
        {
            ConditionEmpty => new ConditionEmptyInternal(data),
            ConditionExists => new ConditionExistsInternal(data),
            ConditionRegex => new ConditionRegexInternal(data),
            ConditionSumEquals => new ConditionSumEqualsInternal(data),
            ConditionCompare conditionCompare => new ConditionCompareInternal(data, FromDomain(conditionCompare.CompareType)),
            ConditionExistsAny => new ConditionExistsAnyInternal(data),
            ConditionExistsWithReferencePrecondition conditionExistsWithReferencePrecondition => new ConditionExistsWithReferencePreconditionInternal(
                data,
                conditionExistsWithReferencePrecondition.PreconditionReferenceId),
            ConditionCompareReferenceValue conditionReferenceValueCompare => new ConditionCompareReferenceValueInternal(
                data,
                FromDomain(conditionReferenceValueCompare.CompareType)),
            _ => throw new ArgumentTypeOutOfRangeException(condition)
        };

        return result;
    }

    internal static ICondition ToDomain(ConditionBaseInternal condition)
    {
        ConditionData data = ConditionDataInternalConverter.ToDomain(condition.Data);

        ConditionBase result = condition switch
        {
            ConditionEmptyInternal => new ConditionEmpty(data),
            ConditionExistsInternal => new ConditionExists(data),
            ConditionRegexInternal => new ConditionRegex(data),
            ConditionSumEqualsInternal => new ConditionSumEquals(data),
            ConditionCompareInternal conditionCompareInternal => new ConditionCompare(data, ToDomain(conditionCompareInternal.ConditionCompareType)),
            ConditionExistsAnyInternal => new ConditionExistsAny(data),
            ConditionExistsWithReferencePreconditionInternal conditionExistsWithReferencePrecondition => new ConditionExistsWithReferencePrecondition(
                data,
                conditionExistsWithReferencePrecondition.PreconditionReferenceId),
            ConditionCompareReferenceValueInternal conditionCompareInternal => new ConditionCompareReferenceValue(
                data,
                ToDomain(conditionCompareInternal.ConditionCompareType)),
            _ => throw new ArgumentTypeOutOfRangeException(condition)
        };

        return result;
    }

    private static ConditionCompareType ToDomain(ConditionCompareTypeInternal compareType)
    {
        ConditionCompareType result = compareType switch
        {
            ConditionCompareTypeInternal.Great => ConditionCompareType.Great,
            ConditionCompareTypeInternal.GreatOrEqual => ConditionCompareType.GreatOrEqual,
            ConditionCompareTypeInternal.Equal => ConditionCompareType.Equal,
            ConditionCompareTypeInternal.LessOrEqual => ConditionCompareType.LessOrEqual,
            ConditionCompareTypeInternal.Less => ConditionCompareType.Less,
            ConditionCompareTypeInternal.None => ConditionCompareType.None,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return result;
    }

    private static ConditionCompareTypeInternal FromDomain(ConditionCompareType compareType)
    {
        ConditionCompareTypeInternal result = compareType switch
        {
            ConditionCompareType.Great => ConditionCompareTypeInternal.Great,
            ConditionCompareType.GreatOrEqual => ConditionCompareTypeInternal.GreatOrEqual,
            ConditionCompareType.Equal => ConditionCompareTypeInternal.Equal,
            ConditionCompareType.LessOrEqual => ConditionCompareTypeInternal.LessOrEqual,
            ConditionCompareType.Less => ConditionCompareTypeInternal.Less,
            ConditionCompareType.None => ConditionCompareTypeInternal.None,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return result;
    }

    private static ConditionCompareReferenceValueType ToDomain(ConditionCompareReferenceValueTypeInternal compareType)
    {
        ConditionCompareReferenceValueType result = compareType switch
        {
            ConditionCompareReferenceValueTypeInternal.OneOf => ConditionCompareReferenceValueType.OneOf,
            ConditionCompareReferenceValueTypeInternal.NoOneOf => ConditionCompareReferenceValueType.NoOneOf,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return result;
    }

    private static ConditionCompareReferenceValueTypeInternal FromDomain(ConditionCompareReferenceValueType compareType)
    {
        ConditionCompareReferenceValueTypeInternal result = compareType switch
        {
            ConditionCompareReferenceValueType.OneOf => ConditionCompareReferenceValueTypeInternal.OneOf,
            ConditionCompareReferenceValueType.NoOneOf => ConditionCompareReferenceValueTypeInternal.NoOneOf,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return result;
    }
}
