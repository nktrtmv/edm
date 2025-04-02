using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions.ValueObjects.Targets;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Validators.Conditions;

internal static class ConditionDataDbConverter
{
    public static ConditionData ToDomain(ConditionDataDb condition)
    {
        Id<ICondition> conditionId = IdConverterFrom<ICondition>
            .FromString(condition.ConditionId);

        Id<DocumentAttribute>[] linkedDocumentAttributes = condition.LinkedDocumentAttributeIds
            .Select(IdConverterFrom<DocumentAttribute>.FromString)
            .ToArray();

        IConditionTarget? target = NullableConverter
            .Convert(condition.ConditionTarget, ConditionTargetDbConverter.ToDomain);

        Id<DocumentStatus>[] supportedDocumentStatusIds = condition.SupportedDocumentStatusIds
            .Select(IdConverterFrom<DocumentStatus>.FromString)
            .ToArray();

        var result = new ConditionData(conditionId, linkedDocumentAttributes, target, supportedDocumentStatusIds);

        return result;
    }

    public static ConditionDataDb FromDomain(ConditionData condition)
    {
        var conditionId = IdConverterTo
            .ToString(condition.ConditionId);

        IEnumerable<string> linkedDocumentAttributeIds = condition.LinkedDocumentAttributeIds
            .Select(IdConverterTo.ToString);

        IEnumerable<string> supportedDocumentStatusIds = condition.SupportedDocumentStatusIds
            .Select(IdConverterTo.ToString);

        OneOfConditionTargetDb? conditionTargetDb = NullableConverter.Convert(condition.Target, ConditionTargetDbConverter.FromDomain);

        var result = new ConditionDataDb
        {
            ConditionId = conditionId,
            LinkedDocumentAttributeIds =
            {
                linkedDocumentAttributeIds
            },
            SupportedDocumentStatusIds =
            {
                supportedDocumentStatusIds
            },
            ConditionTarget = conditionTargetDb
        };

        return result;
    }
}
