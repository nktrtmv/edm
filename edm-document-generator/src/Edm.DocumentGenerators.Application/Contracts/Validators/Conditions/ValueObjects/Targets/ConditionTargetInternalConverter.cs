using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects.Targets;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects.Targets;

internal static class ConditionTargetInternalConverter
{
    internal static IConditionTargetInternal FromDomain(IConditionTarget target)
    {
        IConditionTargetInternal result = target switch
        {
            ConditionTargetDocumentAttribute t =>
                new ConditionTargetDocumentAttributeInternal(IdConverterFrom<DocumentAttributeInternal>.From(t.DocumentAttributeId)),

            ConditionTargetConstantValueGeneric<Number<NumberDocumentAttributeValue>> t =>
                new ConditionTargetConstantValueGenericInternal<long>(NumberConverterTo.ToLong(t.Value)),

            ConditionTargetConstantValueGeneric<bool> t =>
                new ConditionTargetConstantValueGenericInternal<bool>(t.Value),

            ConditionTargetConstantValueGeneric<DateTime> t =>
                new ConditionTargetConstantValueGenericInternal<DateTime>(t.Value),

            ConditionTargetConstantValueGeneric<string> t =>
                new ConditionTargetConstantValueGenericInternal<string>(t.Value),

            ConditionTargetConstantValueGeneric<string[]> t =>
                new ConditionTargetConstantValueReferenceInternal(t.Value),

            _ => throw new ArgumentTypeOutOfRangeException(target)
        };

        return result;
    }

    internal static IConditionTarget ToDomain(IConditionTargetInternal target)
    {
        return target switch
        {
            ConditionTargetDocumentAttributeInternal t =>
                new ConditionTargetDocumentAttribute(IdConverterFrom<DocumentAttribute>.From(t.DocumentAttributeId)),

            ConditionTargetConstantValueGenericInternal<long> t =>
                new ConditionTargetConstantValueGeneric<Number<NumberDocumentAttributeValue>>(NumberConverterFrom<NumberDocumentAttributeValue>.FromLong(t.Value)),

            ConditionTargetConstantValueGenericInternal<bool> t =>
                new ConditionTargetConstantValueGeneric<bool>(t.Value),

            ConditionTargetConstantValueGenericInternal<DateTime> t =>
                new ConditionTargetConstantValueGeneric<DateTime>(t.Value),

            ConditionTargetConstantValueGenericInternal<string> t =>
                new ConditionTargetConstantValueGeneric<string>(t.Value),

            ConditionTargetConstantValueReferenceInternal t =>
                new ConditionTargetConstantValueGeneric<string[]>(t.Values),

            _ => throw new ArgumentTypeOutOfRangeException(target)
        };
    }
}
