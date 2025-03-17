using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions;
using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects;
using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects.Targets;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Validators;

internal static class ConditionDataDtoConverter
{
    internal static ConditionDataInternal ToInternal(ConditionDataDto signature)
    {
        Id<ConditionBaseInternal> id = IdConverterFrom<ConditionBaseInternal>
            .FromString(signature.ConditionId);

        Id<DocumentAttributeInternal>[] linkedDocumentAttributeIds = signature.LinkedDocumentAttributeIds
            .Select(IdConverterFrom<DocumentAttributeInternal>.FromString)
            .ToArray();

        IConditionTargetInternal? target = ConditionTargetDtoConverter.ToInternal(signature.ConditionTarget);

        Id<DocumentStatusInternal>[] supportedDocumentStatusIds = signature.SupportedDocumentStatusIds
            .Select(IdConverterFrom<DocumentStatusInternal>.FromString)
            .ToArray();

        var conditionDataInternal = new ConditionDataInternal(
            id,
            linkedDocumentAttributeIds,
            target,
            supportedDocumentStatusIds);

        return conditionDataInternal;
    }

    internal static ConditionDataDto FromInternal(ConditionDataInternal data)
    {
        var conditionId = IdConverterTo.ToString(data.ConditionId);
        IEnumerable<string> linkedDocumentAttributeIds = data.LinkedDocumentAttributeIds.Select(IdConverterTo.ToString);
        OneOfConditionTargetDto? target = ConditionTargetDtoConverter.FromInternal(data.Target);
        IEnumerable<string> supportedDocumentStatusIds = data.SupportedDocumentStatusIds.Select(IdConverterTo.ToString);

        var conditionDataDto = new ConditionDataDto
        {
            ConditionId = conditionId,
            LinkedDocumentAttributeIds = { linkedDocumentAttributeIds },
            ConditionTarget = target,
            SupportedDocumentStatusIds = { supportedDocumentStatusIds }
        };

        return conditionDataDto;
    }
}
