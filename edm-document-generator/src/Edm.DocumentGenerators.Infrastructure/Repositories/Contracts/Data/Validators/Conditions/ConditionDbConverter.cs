using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ForDocumentAttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ForDocumentAttributesValues.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Validators.Conditions;

internal static class ConditionDbConverter
{
    internal static ICondition ToDomain(OneOfConditionDb condition)
    {
        switch (condition.ValueCase)
        {
            case OneOfConditionDb.ValueOneofCase.AsExist:
                ConditionData data = ConditionDataDbConverter.ToDomain(condition.AsExist.Data);

                return new ConditionExists(data);

            case OneOfConditionDb.ValueOneofCase.AsIsEmpty:
                data = ConditionDataDbConverter.ToDomain(condition.AsIsEmpty.Data);

                return new ConditionEmpty(data);

            case OneOfConditionDb.ValueOneofCase.AsRegex:
                data = ConditionDataDbConverter.ToDomain(condition.AsRegex.Data);

                return new ConditionRegex(data);

            case OneOfConditionDb.ValueOneofCase.AsSumEquals:
                data = ConditionDataDbConverter.ToDomain(condition.AsSumEquals.Data);

                return new ConditionSumEquals(data);

            case OneOfConditionDb.ValueOneofCase.AsCompare:
                data = ConditionDataDbConverter.ToDomain(condition.AsCompare.Data);

                return new ConditionCompare(data, ToDomain(condition.AsCompare.CompareType));

            case OneOfConditionDb.ValueOneofCase.AsExistsAny:
                data = ConditionDataDbConverter.ToDomain(condition.AsExistsAny.Data);

                return new ConditionExistsAny(data);

            case OneOfConditionDb.ValueOneofCase.AsExistsWithReferencePrecondition:
                data = ConditionDataDbConverter.ToDomain(condition.AsExistsWithReferencePrecondition.Data);

                return new ConditionExistsWithReferencePrecondition(data, condition.AsExistsWithReferencePrecondition.PreconditionReferenceId);

            case OneOfConditionDb.ValueOneofCase.AsCompareReferenceValue:
                data = ConditionDataDbConverter.ToDomain(condition.AsCompareReferenceValue.Data);
                ConditionCompareReferenceValueType compareType = ToDomain(condition.AsCompareReferenceValue.CompareType);

                return new ConditionCompareReferenceValue(data, compareType);

            default:
                throw new ArgumentTypeOutOfRangeException(condition);
        }
    }

    internal static OneOfConditionDb FromDomain(ICondition condition)
    {
        OneOfConditionDb result = condition switch
        {
            ConditionExists domainCondition => new OneOfConditionDb
            {
                AsExist = new ConditionExistsDb { Data = ConditionDataDbConverter.FromDomain(domainCondition.Data) }
            },
            ConditionEmpty domainCondition => new OneOfConditionDb
            {
                AsIsEmpty = new ConditionEmptyDb { Data = ConditionDataDbConverter.FromDomain(domainCondition.Data) }
            },
            ConditionRegex domainCondition => new OneOfConditionDb
            {
                AsRegex = new ConditionRegexDb { Data = ConditionDataDbConverter.FromDomain(domainCondition.Data) }
            },
            ConditionSumEquals domainCondition => new OneOfConditionDb
            {
                AsSumEquals = new ConditionSumEqualsDb { Data = ConditionDataDbConverter.FromDomain(domainCondition.Data) }
            },
            ConditionCompare domainCondition => new OneOfConditionDb
            {
                AsCompare = new ConditionCompareDb
                {
                    Data = ConditionDataDbConverter.FromDomain(domainCondition.Data),
                    CompareType = FromDomain(domainCondition.CompareType)
                }
            },
            ConditionExistsAny domainCondition => new OneOfConditionDb
            {
                AsExistsAny = new ConditionExistsAnyDb
                {
                    Data = ConditionDataDbConverter.FromDomain(domainCondition.Data)
                }
            },
            ConditionExistsWithReferencePrecondition domainCondition => new OneOfConditionDb
            {
                AsExistsWithReferencePrecondition = new ConditionExistsWithReferencePreconditionDb
                {
                    Data = ConditionDataDbConverter.FromDomain(domainCondition.Data),
                    PreconditionReferenceId = domainCondition.PreconditionReferenceId
                }
            },
            ConditionCompareReferenceValue domainCondition => new OneOfConditionDb
            {
                AsCompareReferenceValue = new ConditionCompareReferenceValueDb
                {
                    Data = ConditionDataDbConverter.FromDomain(domainCondition.Data),
                    CompareType = FromDomain(domainCondition.CompareType)
                }
            },
            _ => throw new ArgumentTypeOutOfRangeException(condition)
        };

        return result;
    }

    private static ConditionCompareType ToDomain(ConditionCompareTypeDb compareType)
    {
        ConditionCompareType result = compareType switch
        {
            ConditionCompareTypeDb.Great => ConditionCompareType.Great,
            ConditionCompareTypeDb.GreatOrEqual => ConditionCompareType.GreatOrEqual,
            ConditionCompareTypeDb.Equal => ConditionCompareType.Equal,
            ConditionCompareTypeDb.LessOrEqual => ConditionCompareType.LessOrEqual,
            ConditionCompareTypeDb.Less => ConditionCompareType.Less,
            ConditionCompareTypeDb.None => ConditionCompareType.None,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return result;
    }

    private static ConditionCompareTypeDb FromDomain(ConditionCompareType compareType)
    {
        ConditionCompareTypeDb result = compareType switch
        {
            ConditionCompareType.Great => ConditionCompareTypeDb.Great,
            ConditionCompareType.GreatOrEqual => ConditionCompareTypeDb.GreatOrEqual,
            ConditionCompareType.Equal => ConditionCompareTypeDb.Equal,
            ConditionCompareType.LessOrEqual => ConditionCompareTypeDb.LessOrEqual,
            ConditionCompareType.Less => ConditionCompareTypeDb.Less,
            ConditionCompareType.None => ConditionCompareTypeDb.None,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return result;
    }

    private static ConditionCompareReferenceValueType ToDomain(ConditionCompareReferenceValueTypeDb compareType)
    {
        ConditionCompareReferenceValueType result = compareType switch
        {
            ConditionCompareReferenceValueTypeDb.OneOf => ConditionCompareReferenceValueType.OneOf,
            ConditionCompareReferenceValueTypeDb.NoOneOf => ConditionCompareReferenceValueType.NoOneOf,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return result;
    }

    private static ConditionCompareReferenceValueTypeDb FromDomain(ConditionCompareReferenceValueType compareType)
    {
        ConditionCompareReferenceValueTypeDb result = compareType switch
        {
            ConditionCompareReferenceValueType.OneOf => ConditionCompareReferenceValueTypeDb.OneOf,
            ConditionCompareReferenceValueType.NoOneOf => ConditionCompareReferenceValueTypeDb.NoOneOf,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return result;
    }
}
