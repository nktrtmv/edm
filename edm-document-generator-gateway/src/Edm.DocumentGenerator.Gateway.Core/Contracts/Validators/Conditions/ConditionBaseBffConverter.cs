using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ForDocumentAttributeValues;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ForDocumentAttributeValues.ValueObjects;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions;

internal static class ConditionBaseBffConverter
{
    internal static ConditionBaseBff ToBff(OneOfConditionDto conditionDto)
    {
        ConditionBaseBff condition = conditionDto.ValueCase switch
        {
            OneOfConditionDto.ValueOneofCase.AsExist =>
                new ConditionExistsBff(ConditionDataBffConverter.ToBff(conditionDto.AsExist.Data)),
            OneOfConditionDto.ValueOneofCase.AsIsEmpty =>
                new ConditionEmptyBff(ConditionDataBffConverter.ToBff(conditionDto.AsIsEmpty.Data)),
            OneOfConditionDto.ValueOneofCase.AsRegex =>
                new ConditionRegexBff(ConditionDataBffConverter.ToBff(conditionDto.AsRegex.Data)),
            OneOfConditionDto.ValueOneofCase.AsSumEquals =>
                new ConditionSumEqualsBff(ConditionDataBffConverter.ToBff(conditionDto.AsSumEquals.Data)),
            OneOfConditionDto.ValueOneofCase.AsCompare =>
                new ConditionCompareBff(
                    ConditionDataBffConverter.ToBff(conditionDto.AsCompare.Data),
                    ToBff(conditionDto.AsCompare.CompareType)),
            OneOfConditionDto.ValueOneofCase.AsExistsAny =>
                new ConditionExistsAnyBff(ConditionDataBffConverter.ToBff(conditionDto.AsExistsAny.Data)),
            OneOfConditionDto.ValueOneofCase.AsExistsWithReferencePrecondition =>
                new ConditionExistsWithReferencePreconditionBff(
                    ConditionDataBffConverter.ToBff(conditionDto.AsExistsWithReferencePrecondition.Data),
                    conditionDto.AsExistsWithReferencePrecondition.PreconditionReferenceId),
            OneOfConditionDto.ValueOneofCase.AsCompareReferenceValue =>
                new ConditionCompareReferenceBff(
                    ConditionDataBffConverter.ToBff(conditionDto.AsCompareReferenceValue.Data),
                    ToBff(conditionDto.AsCompareReferenceValue.CompareType)),

            _ => throw new ArgumentTypeOutOfRangeException(conditionDto.ValueCase)
        };

        return condition;
    }

    internal static OneOfConditionDto FromBff(ConditionBaseBff conditionBff)
    {
        var conditionData = ConditionDataBffConverter.FromBff(conditionBff.Data);

        var condition = conditionBff switch
        {
            ConditionEmptyBff => new OneOfConditionDto
            {
                AsIsEmpty = new ConditionEmptyDto { Data = conditionData }
            },
            ConditionExistsBff => new OneOfConditionDto
            {
                AsExist = new ConditionExistsDto { Data = conditionData }
            },

            ConditionRegexBff => new OneOfConditionDto
            {
                AsRegex = new ConditionRegexDto { Data = conditionData }
            },
            ConditionSumEqualsBff => new OneOfConditionDto
            {
                AsSumEquals = new ConditionSumEqualsDto { Data = conditionData }
            },
            ConditionCompareBff conditionCompareBff => new OneOfConditionDto
            {
                AsCompare = new ConditionCompareDto
                {
                    Data = conditionData,
                    CompareType = FromBff(conditionCompareBff.ConditionCompareType)
                }
            },
            ConditionExistsAnyBff => new OneOfConditionDto
            {
                AsExistsAny = new ConditionExistsAnyDto
                {
                    Data = conditionData
                }
            },
            ConditionExistsWithReferencePreconditionBff conditionExistsWithReferencePreconditionBff => new OneOfConditionDto
            {
                AsExistsWithReferencePrecondition = new ConditionExistsWithReferencePreconditionDto
                {
                    Data = conditionData,
                    PreconditionReferenceId = conditionExistsWithReferencePreconditionBff.PreconditionReferenceId
                }
            },
            ConditionCompareReferenceBff conditionCompareBff => new OneOfConditionDto
            {
                AsCompareReferenceValue = new ConditionCompareReferenceValueDto
                {
                    Data = conditionData,
                    CompareType = FromBff(conditionCompareBff.ConditionCompareReferenceType)
                }
            },
            _ => throw new ArgumentTypeOutOfRangeException(conditionBff)
        };

        return condition;
    }

    private static ConditionCompareTypeDto FromBff(ConditionCompareTypeBff compareType)
    {
        var type = compareType switch
        {
            ConditionCompareTypeBff.Great => ConditionCompareTypeDto.Great,
            ConditionCompareTypeBff.GreatOrEqual => ConditionCompareTypeDto.GreatOrEqual,
            ConditionCompareTypeBff.Equal => ConditionCompareTypeDto.Equal,
            ConditionCompareTypeBff.LessOrEqual => ConditionCompareTypeDto.LessOrEqual,
            ConditionCompareTypeBff.Less => ConditionCompareTypeDto.Less,
            ConditionCompareTypeBff.None => ConditionCompareTypeDto.None,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return type;
    }

    private static ConditionCompareReferenceValueTypeDto FromBff(ConditionCompareReferenceTypeBff compareType)
    {
        var type = compareType switch
        {
            ConditionCompareReferenceTypeBff.OneOf => ConditionCompareReferenceValueTypeDto.OneOf,
            ConditionCompareReferenceTypeBff.NoOneOf => ConditionCompareReferenceValueTypeDto.NoOneOf,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return type;
    }

    private static ConditionCompareTypeBff ToBff(ConditionCompareTypeDto compareType)
    {
        var type = compareType switch
        {
            ConditionCompareTypeDto.Great => ConditionCompareTypeBff.Great,
            ConditionCompareTypeDto.GreatOrEqual => ConditionCompareTypeBff.GreatOrEqual,
            ConditionCompareTypeDto.Equal => ConditionCompareTypeBff.Equal,
            ConditionCompareTypeDto.LessOrEqual => ConditionCompareTypeBff.LessOrEqual,
            ConditionCompareTypeDto.Less => ConditionCompareTypeBff.Less,
            ConditionCompareTypeDto.None => ConditionCompareTypeBff.None,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return type;
    }

    private static ConditionCompareReferenceTypeBff ToBff(ConditionCompareReferenceValueTypeDto compareType)
    {
        var type = compareType switch
        {
            ConditionCompareReferenceValueTypeDto.OneOf => ConditionCompareReferenceTypeBff.OneOf,
            ConditionCompareReferenceValueTypeDto.NoOneOf => ConditionCompareReferenceTypeBff.NoOneOf,
            _ => throw new ArgumentTypeOutOfRangeException(compareType)
        };

        return type;
    }
}
