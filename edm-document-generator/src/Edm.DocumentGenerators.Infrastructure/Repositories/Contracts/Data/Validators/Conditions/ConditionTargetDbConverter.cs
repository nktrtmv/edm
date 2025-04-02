using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects.Targets;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Validators.Conditions;

internal static class ConditionTargetDbConverter
{
    public static IConditionTarget ToDomain(OneOfConditionTargetDb target)
    {
        IConditionTarget result = (target.ValueCase switch
        {
            OneOfConditionTargetDb.ValueOneofCase.TargetDocumentAttribute => new ConditionTargetDocumentAttribute(
                IdConverterFrom<DocumentAttribute>.FromString(target.TargetDocumentAttribute.Id)),
            OneOfConditionTargetDb.ValueOneofCase.TargetConstantValue => NullableConverter.Convert(target.TargetConstantValue, ConditionTargetConstantValueFromDb),
            OneOfConditionTargetDb.ValueOneofCase.None => null,
            _ => throw new ArgumentTypeOutOfRangeException(target.ValueCase)
        })!;

        return result;
    }

    public static OneOfConditionTargetDb FromDomain(IConditionTarget conditionTarget)
    {
        OneOfConditionTargetDb conditionTargetDb = (conditionTarget switch
        {
            null => null,
            ConditionTargetDocumentAttribute conditionTargetDocumentAttribute =>
                new OneOfConditionTargetDb
                {
                    TargetDocumentAttribute = new ConditionTargetDocumentAttributeDb
                    {
                        Id = IdConverterTo.ToString(conditionTargetDocumentAttribute.DocumentAttributeId)
                    }
                },
            ConditionTargetConstantValue conditionTargetConstantValue => new OneOfConditionTargetDb
            {
                TargetConstantValue = NullableConverter.Convert(conditionTargetConstantValue, ConditionTargetConstantValueToDb)
            },
            _ => throw new ArgumentTypeOutOfRangeException(conditionTarget)
        })!;

        return conditionTargetDb;
    }

    private static IConditionTarget ConditionTargetConstantValueFromDb(OneOfConditionTargetConstantValueDb target)
    {
        IConditionTarget result = target.ValueCase switch
        {
            OneOfConditionTargetConstantValueDb.ValueOneofCase.Boolean =>
                new ConditionTargetConstantValueGeneric<bool>(target.Boolean),
            OneOfConditionTargetConstantValueDb.ValueOneofCase.Int =>
                new ConditionTargetConstantValueGeneric<Number<NumberDocumentAttributeValue>>(NumberConverterFrom<NumberDocumentAttributeValue>.FromInt(target.Int)),
            OneOfConditionTargetConstantValueDb.ValueOneofCase.Number =>
                new ConditionTargetConstantValueGeneric<Number<NumberDocumentAttributeValue>>(NumberConverterFrom<NumberDocumentAttributeValue>.FromLong(target.Number)),
            OneOfConditionTargetConstantValueDb.ValueOneofCase.DateTime =>
                new ConditionTargetConstantValueGeneric<DateTime>(target.DateTime.ToDateTime()),
            OneOfConditionTargetConstantValueDb.ValueOneofCase.String =>
                new ConditionTargetConstantValueGeneric<string>(target.String),
            OneOfConditionTargetConstantValueDb.ValueOneofCase.ReferenceValues =>
                new ConditionTargetConstantValueGeneric<string[]>(target.ReferenceValues.Values.Select(value => value.ToString()).ToArray()),
            _ => throw new ArgumentTypeOutOfRangeException(target)
        };

        return result;
    }

    private static OneOfConditionTargetConstantValueDb ConditionTargetConstantValueToDb(ConditionTargetConstantValue target)
    {
        OneOfConditionTargetConstantValueDb result = target switch
        {
            ConditionTargetConstantValueGeneric<bool> t => new OneOfConditionTargetConstantValueDb
            {
                Boolean = t.Value
            },
            ConditionTargetConstantValueGeneric<Number<NumberDocumentAttributeValue>> t => new OneOfConditionTargetConstantValueDb
            {
                Number = NumberConverterTo.ToLong(t.Value)
            },
            ConditionTargetConstantValueGeneric<DateTime> t => new OneOfConditionTargetConstantValueDb
            {
                DateTime = Timestamp.FromDateTime(t.Value)
            },
            ConditionTargetConstantValueGeneric<string> t => new OneOfConditionTargetConstantValueDb
            {
                String = t.Value
            },
            ConditionTargetConstantValueGeneric<string[]> t => new OneOfConditionTargetConstantValueDb
            {
                ReferenceValues = new ReferenceValuesDb
                {
                    Values =
                    {
                        t.Value
                    }
                }
            },
            _ => throw new ArgumentTypeOutOfRangeException(target)
        };

        return result;
    }
}
