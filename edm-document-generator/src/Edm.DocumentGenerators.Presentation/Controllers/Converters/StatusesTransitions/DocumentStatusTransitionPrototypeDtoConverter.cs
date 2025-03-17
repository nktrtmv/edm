using Edm.DocumentGenerators.Application.Contracts.Permissions;
using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Parameters;
using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Types;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Statuses;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.StatusesTransitions;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Permissions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.StatusesTransitions.Parameters;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.StatusesTransitions.Types;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes.Statuses;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.StatusesTransitions;

internal static class DocumentStatusTransitionPrototypeDtoConverter
{
    internal static DocumentStatusTransitionPrototypeDto FromInternal(DocumentStatusTransitionPrototypeInternal transition)
    {
        DocumentStatusTransitionTypeDto type = DocumentStatusTransitionTypeDtoConverter.FromInternal(transition.Type);

        DocumentStatusPrototypeDto from = DocumentStatusPrototypeDtoConverter.FromInternal(transition.From);

        DocumentStatusPrototypeDto to = DocumentStatusPrototypeDtoConverter.FromInternal(transition.To);

        DocumentStatusTransitionParameterDto[] parameters = transition.Parameters.Select(DocumentStatusTransitionParameterDtoConverter.FromInternal).ToArray();

        DocumentPermissionDto[] permissions = transition.Permissions.Select(DocumentPermissionDtoConverter.FromInternal).ToArray();

        var result = new DocumentStatusTransitionPrototypeDto
        {
            Id = transition.Id,
            Type = type,
            From = from,
            To = to,
            Parameters = { parameters },
            Permissions = { permissions },
            SystemName = transition.SystemName,
            DisplayName = transition.DisplayName
        };

        return result;
    }

    internal static DocumentStatusTransitionPrototypeInternal ToInternal(DocumentStatusTransitionPrototypeDto transition)
    {
        DocumentStatusTransitionTypeInternal type = DocumentStatusTransitionTypeDtoConverter.ToInternal(transition.Type);

        DocumentStatusPrototypeInternal from = DocumentStatusPrototypeDtoConverter.ToInternal(transition.From);

        DocumentStatusPrototypeInternal to = DocumentStatusPrototypeDtoConverter.ToInternal(transition.To);

        DocumentStatusTransitionParameterInternal[] parameters = transition.Parameters.Select(DocumentStatusTransitionParameterDtoConverter.ToInternal).ToArray();

        DocumentPermissionInternal[] permissions = transition.Permissions.Select(DocumentPermissionDtoConverter.ToInternal).ToArray();

        var result = new DocumentStatusTransitionPrototypeInternal(transition.Id, type, from, to, parameters, permissions, transition.SystemName, transition.DisplayName);

        return result;
    }
}
