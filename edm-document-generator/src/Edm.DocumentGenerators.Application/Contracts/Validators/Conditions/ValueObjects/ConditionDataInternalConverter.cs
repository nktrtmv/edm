using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects.Targets;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects.Targets;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects;

internal static class ConditionDataInternalConverter
{
    internal static ConditionDataInternal FromDomain(ConditionData data)
    {
        Id<ConditionBaseInternal> conditionId =
            IdConverterFrom<ConditionBaseInternal>.From(data.ConditionId);

        Id<DocumentAttributeInternal>[] linkedDocumentAttributeIds =
            data.LinkedDocumentAttributeIds.Select(IdConverterFrom<DocumentAttributeInternal>.From).ToArray();

        Id<DocumentStatusInternal>[] supportedDocumentStatusIds =
            data.SupportedDocumentStatusIds.Select(IdConverterFrom<DocumentStatusInternal>.From).ToArray();

        IConditionTargetInternal? target = NullableConverter.Convert(data.Target, ConditionTargetInternalConverter.FromDomain);

        var result = new ConditionDataInternal(
            conditionId,
            linkedDocumentAttributeIds,
            target,
            supportedDocumentStatusIds);

        return result;
    }

    internal static ConditionData ToDomain(ConditionDataInternal data)
    {
        Id<ICondition> conditionId =
            IdConverterFrom<ICondition>.From(data.ConditionId);

        Id<DocumentAttribute>[] linkedDocumentAttributeIds =
            data.LinkedDocumentAttributeIds.Select(IdConverterFrom<DocumentAttribute>.From).ToArray();

        Id<DocumentStatus>[] supportedDocumentStatusIds =
            data.SupportedDocumentStatusIds.Select(IdConverterFrom<DocumentStatus>.From).ToArray();

        IConditionTarget? target = NullableConverter.Convert(data.Target, ConditionTargetInternalConverter.ToDomain);

        var result = new ConditionData(
            conditionId,
            linkedDocumentAttributeIds,
            target,
            supportedDocumentStatusIds);

        return result;
    }
}
