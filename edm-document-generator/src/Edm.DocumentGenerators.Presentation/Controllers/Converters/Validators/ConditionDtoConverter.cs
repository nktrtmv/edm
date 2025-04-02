using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions;
using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ForDocumentAttributesValues;
using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ForDocumentAttributesValues.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Validators;

internal static class ConditionDtoConverter
{
    internal static OneOfConditionDto FromInternal(ConditionBaseInternal conditionInternal)
    {
        ConditionDataDto data = ConditionDataDtoConverter.FromInternal(conditionInternal.Data);

        return conditionInternal switch
        {
            ConditionEmptyInternal =>
                new OneOfConditionDto
                {
                    AsIsEmpty = new ConditionEmptyDto { Data = data }
                },
            ConditionExistsInternal =>
                new OneOfConditionDto
                {
                    AsExist = new ConditionExistsDto { Data = data }
                },
            ConditionRegexInternal =>
                new OneOfConditionDto
                {
                    AsRegex = new ConditionRegexDto { Data = data }
                },
            ConditionSumEqualsInternal =>
                new OneOfConditionDto
                {
                    AsSumEquals = new ConditionSumEqualsDto { Data = data }
                },
            ConditionCompareInternal conditionCompare =>
                new OneOfConditionDto
                {
                    AsCompare = new ConditionCompareDto
                    {
                        Data = data,
                        CompareType = FromInternal(conditionCompare.ConditionCompareType)
                    }
                },
            ConditionExistsAnyInternal =>
                new OneOfConditionDto
                {
                    AsExistsAny = new ConditionExistsAnyDto
                    {
                        Data = data
                    }
                },
            ConditionExistsWithReferencePreconditionInternal conditionExistsWithReferencePrecondition =>
                new OneOfConditionDto
                {
                    AsExistsWithReferencePrecondition = new ConditionExistsWithReferencePreconditionDto
                    {
                        Data = data,
                        PreconditionReferenceId = conditionExistsWithReferencePrecondition.PreconditionReferenceId
                    }
                },
            ConditionCompareReferenceValueInternal conditionCompare =>
                new OneOfConditionDto
                {
                    AsCompareReferenceValue = new ConditionCompareReferenceValueDto
                    {
                        Data = data,
                        CompareType = FromInternal(conditionCompare.ConditionCompareType)
                    }
                },
            _ => throw new ArgumentTypeOutOfRangeException(conditionInternal)
        };
    }

    internal static ConditionBaseInternal ToInternal(OneOfConditionDto condition)
    {
        return condition.ValueCase switch
        {
            OneOfConditionDto.ValueOneofCase.AsExist =>
                new ConditionExistsInternal(ConditionDataDtoConverter.ToInternal(condition.AsExist.Data)),
            OneOfConditionDto.ValueOneofCase.AsIsEmpty =>
                new ConditionEmptyInternal(ConditionDataDtoConverter.ToInternal(condition.AsIsEmpty.Data)),
            OneOfConditionDto.ValueOneofCase.AsRegex =>
                new ConditionRegexInternal(ConditionDataDtoConverter.ToInternal(condition.AsRegex.Data)),
            OneOfConditionDto.ValueOneofCase.AsSumEquals =>
                new ConditionSumEqualsInternal(ConditionDataDtoConverter.ToInternal(condition.AsSumEquals.Data)),
            OneOfConditionDto.ValueOneofCase.AsCompare =>
                new ConditionCompareInternal(ConditionDataDtoConverter.ToInternal(condition.AsCompare.Data), ToInternal(condition.AsCompare.CompareType)),
            OneOfConditionDto.ValueOneofCase.AsExistsAny =>
                new ConditionExistsAnyInternal(ConditionDataDtoConverter.ToInternal(condition.AsExistsAny.Data)),
            OneOfConditionDto.ValueOneofCase.AsExistsWithReferencePrecondition =>
                new ConditionExistsWithReferencePreconditionInternal(
                    ConditionDataDtoConverter.ToInternal(condition.AsExistsWithReferencePrecondition.Data),
                    condition.AsExistsWithReferencePrecondition.PreconditionReferenceId),
            OneOfConditionDto.ValueOneofCase.AsCompareReferenceValue =>
                new ConditionCompareReferenceValueInternal(
                    ConditionDataDtoConverter.ToInternal(condition.AsCompareReferenceValue.Data),
                    ToInternal(condition.AsCompareReferenceValue.CompareType)),
            _ => throw new ArgumentTypeOutOfRangeException(condition.ValueCase)
        };
    }

    private static ConditionCompareTypeInternal ToInternal(ConditionCompareTypeDto compareType)
    {
        return compareType switch
        {
            ConditionCompareTypeDto.Great => ConditionCompareTypeInternal.Great,
            ConditionCompareTypeDto.GreatOrEqual => ConditionCompareTypeInternal.GreatOrEqual,
            ConditionCompareTypeDto.Equal => ConditionCompareTypeInternal.Equal,
            ConditionCompareTypeDto.LessOrEqual => ConditionCompareTypeInternal.LessOrEqual,
            ConditionCompareTypeDto.Less => ConditionCompareTypeInternal.Less,
            ConditionCompareTypeDto.None => ConditionCompareTypeInternal.None,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };
    }

    private static ConditionCompareReferenceValueTypeInternal ToInternal(ConditionCompareReferenceValueTypeDto compareType)
    {
        ConditionCompareReferenceValueTypeInternal type = compareType switch
        {
            ConditionCompareReferenceValueTypeDto.OneOf => ConditionCompareReferenceValueTypeInternal.OneOf,
            ConditionCompareReferenceValueTypeDto.NoOneOf => ConditionCompareReferenceValueTypeInternal.NoOneOf,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return type;
    }

    private static ConditionCompareTypeDto FromInternal(ConditionCompareTypeInternal compareType)
    {
        return compareType switch
        {
            ConditionCompareTypeInternal.Great => ConditionCompareTypeDto.Great,
            ConditionCompareTypeInternal.GreatOrEqual => ConditionCompareTypeDto.GreatOrEqual,
            ConditionCompareTypeInternal.Equal => ConditionCompareTypeDto.Equal,
            ConditionCompareTypeInternal.LessOrEqual => ConditionCompareTypeDto.LessOrEqual,
            ConditionCompareTypeInternal.Less => ConditionCompareTypeDto.Less,
            ConditionCompareTypeInternal.None => ConditionCompareTypeDto.None,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };
    }

    private static ConditionCompareReferenceValueTypeDto FromInternal(ConditionCompareReferenceValueTypeInternal compareType)
    {
        ConditionCompareReferenceValueTypeDto type = compareType switch
        {
            ConditionCompareReferenceValueTypeInternal.OneOf => ConditionCompareReferenceValueTypeDto.OneOf,
            ConditionCompareReferenceValueTypeInternal.NoOneOf => ConditionCompareReferenceValueTypeDto.NoOneOf,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return type;
    }
}
