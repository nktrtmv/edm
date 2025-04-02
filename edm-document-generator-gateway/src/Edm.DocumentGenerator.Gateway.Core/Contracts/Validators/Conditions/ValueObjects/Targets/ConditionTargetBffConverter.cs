using Edm.DocumentGenerators.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects.Targets.ConditionTargetConstantValue;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects.Targets;

internal static class ConditionTargetBffConverter
{
    internal static ConditionTargetBff? ToBff(OneOfConditionTargetDto? target)
    {
        if (target is null)
        {
            return null;
        }

        ConditionTargetBff result = target.ValueCase switch
        {
            OneOfConditionTargetDto.ValueOneofCase.TargetDocumentAttribute =>
                new ConditionTargetDocumentAttributeBff { DocumentAttributeId = target.TargetDocumentAttribute.Id },
            OneOfConditionTargetDto.ValueOneofCase.TargetConstantValue =>
                target.TargetConstantValue.ValueCase switch
                {
                    OneOfConditionTargetConstantValueDto.ValueOneofCase.Number =>
                        new ConditionTargetConstantValueNumberBff { Value = target.TargetConstantValue.Number },
                    OneOfConditionTargetConstantValueDto.ValueOneofCase.Boolean =>
                        new ConditionTargetConstantValueBooleanBff { Value = target.TargetConstantValue.Boolean },
                    OneOfConditionTargetConstantValueDto.ValueOneofCase.DateTime =>
                        new ConditionTargetConstantValueDateTimeBff { Value = target.TargetConstantValue.DateTime.ToDateTime() },
                    OneOfConditionTargetConstantValueDto.ValueOneofCase.String =>
                        new ConditionTargetConstantValueStringBff { Value = target.TargetConstantValue.String },
                    OneOfConditionTargetConstantValueDto.ValueOneofCase.ReferenceValues =>
                        ToBff(target.TargetConstantValue.ReferenceValues),
                    _ => throw new ArgumentTypeOutOfRangeException(target.TargetConstantValue.ValueCase)
                },
            _ => throw new ArgumentTypeOutOfRangeException(target.ValueCase)
        };

        return result;
    }

    internal static OneOfConditionTargetDto? FromBff(ConditionTargetBff? target)
    {
        var result = target switch
        {
            null => null,
            ConditionTargetDocumentAttributeBff t =>
                new OneOfConditionTargetDto
                {
                    TargetDocumentAttribute = new ConditionTargetDocumentAttributeDto { Id = t.DocumentAttributeId }
                },
            ConditionTargetConstantValueGenericBff<long> t =>
                new OneOfConditionTargetDto
                {
                    TargetConstantValue = new OneOfConditionTargetConstantValueDto { Number = t.Value }
                },
            ConditionTargetConstantValueGenericBff<bool> t =>
                new OneOfConditionTargetDto
                {
                    TargetConstantValue = new OneOfConditionTargetConstantValueDto { Boolean = t.Value }
                },
            ConditionTargetConstantValueGenericBff<DateTime> t =>
                new OneOfConditionTargetDto
                {
                    TargetConstantValue = new OneOfConditionTargetConstantValueDto { DateTime = Timestamp.FromDateTime(t.Value) }
                },
            ConditionTargetConstantValueGenericBff<string> t =>
                new OneOfConditionTargetDto
                {
                    TargetConstantValue = new OneOfConditionTargetConstantValueDto { String = t.Value }
                },
            ConditionTargetConstantValueReferenceBff t => new OneOfConditionTargetDto
            {
                TargetConstantValue = new OneOfConditionTargetConstantValueDto
                {
                    ReferenceValues = new ReferenceValuesDto
                    {
                        Values = { t.Values }
                    }
                }
            },

            _ => throw new ArgumentTypeOutOfRangeException(target)
        };

        return result;
    }

    private static ConditionTargetConstantValueReferenceBff ToBff(ReferenceValuesDto referenceValues)
    {
        string[] values = referenceValues.Values.Select(value => value.ToString()).ToArray();

        var result = new ConditionTargetConstantValueReferenceBff
        {
            Values = values
        };

        return result;
    }
}
