using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects.Targets;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Validators;

public static class ConditionTargetDtoConverter
{
    internal static IConditionTargetInternal? ToInternal(OneOfConditionTargetDto? conditionTarget)
    {
        if (conditionTarget is null)
        {
            return null;
        }

        return conditionTarget.ValueCase switch
        {
            OneOfConditionTargetDto.ValueOneofCase.TargetDocumentAttribute =>
                new ConditionTargetDocumentAttributeInternal(IdConverterFrom<DocumentAttributeInternal>.FromString(conditionTarget.TargetDocumentAttribute.Id)),
            OneOfConditionTargetDto.ValueOneofCase.TargetConstantValue =>
                conditionTarget.TargetConstantValue.ValueCase switch
                {
                    OneOfConditionTargetConstantValueDto.ValueOneofCase.Boolean =>
                        new ConditionTargetConstantValueGenericInternal<bool>(conditionTarget.TargetConstantValue.Boolean),
                    OneOfConditionTargetConstantValueDto.ValueOneofCase.Number =>
                        new ConditionTargetConstantValueGenericInternal<long>(conditionTarget.TargetConstantValue.Number),
                    OneOfConditionTargetConstantValueDto.ValueOneofCase.DateTime =>
                        new ConditionTargetConstantValueGenericInternal<DateTime>(conditionTarget.TargetConstantValue.DateTime.ToDateTime()),
                    OneOfConditionTargetConstantValueDto.ValueOneofCase.String =>
                        new ConditionTargetConstantValueGenericInternal<string>(conditionTarget.TargetConstantValue.String),
                    OneOfConditionTargetConstantValueDto.ValueOneofCase.ReferenceValues =>
                        new ConditionTargetConstantValueReferenceInternal(ToInternal(conditionTarget.TargetConstantValue.ReferenceValues)),
                    _ => throw new ArgumentTypeOutOfRangeException(conditionTarget.TargetConstantValue.ValueCase)
                },
            _ => throw new ArgumentTypeOutOfRangeException(conditionTarget.ValueCase)
        };
    }

    internal static OneOfConditionTargetDto? FromInternal(IConditionTargetInternal? targetInternal)
    {
        return targetInternal switch
        {
            null => null,
            ConditionTargetDocumentAttributeInternal target =>
                new OneOfConditionTargetDto
                {
                    TargetDocumentAttribute = new ConditionTargetDocumentAttributeDto
                    {
                        Id = IdConverterTo.ToString(target.DocumentAttributeId)
                    }
                },
            ConditionTargetConstantValueGenericInternal<long> target =>
                new OneOfConditionTargetDto
                {
                    TargetConstantValue = new OneOfConditionTargetConstantValueDto
                    {
                        Number = target.Value
                    }
                },
            ConditionTargetConstantValueGenericInternal<bool> target =>
                new OneOfConditionTargetDto
                {
                    TargetConstantValue = new OneOfConditionTargetConstantValueDto
                    {
                        Boolean = target.Value
                    }
                },
            ConditionTargetConstantValueGenericInternal<DateTime> target =>
                new OneOfConditionTargetDto
                {
                    TargetConstantValue = new OneOfConditionTargetConstantValueDto
                    {
                        DateTime = Timestamp.FromDateTime(target.Value)
                    }
                },
            ConditionTargetConstantValueGenericInternal<string> target =>
                new OneOfConditionTargetDto
                {
                    TargetConstantValue = new OneOfConditionTargetConstantValueDto
                    {
                        String = target.Value
                    }
                },
            ConditionTargetConstantValueReferenceInternal target =>
                new OneOfConditionTargetDto
                {
                    TargetConstantValue = new OneOfConditionTargetConstantValueDto
                    {
                        ReferenceValues = new ReferenceValuesDto
                        {
                            Values =
                            {
                                target.Values
                            }
                        }
                    }
                },
            _ => throw new ArgumentTypeOutOfRangeException(targetInternal)
        };
    }

    private static string[] ToInternal(ReferenceValuesDto referenceValues)
    {
        string[] values = referenceValues.Values.Select(value => value.ToString()).ToArray();

        return values;
    }
}
