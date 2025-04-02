using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.StatusesTransitions;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Permissions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.StatusesTransitions.Parameters;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.StatusesTransitions.Types;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.StatusTransitions;

internal static class DocumentStatusTransitionDetailedDtoConverter
{
    internal static DocumentStatusTransitionDetailedDto FromInternal(DocumentStatusTransitionDetailedInternal transition)
    {
        DocumentStatusDto status = DocumentStatusDtoConverter.FromInternal(transition.Status);

        DocumentStatusTransitionTypeDto type = DocumentStatusTransitionTypeDtoConverter.FromInternal(transition.Type);

        DocumentStatusTransitionParameterDto[] parameters =
            transition.Parameters.Select(DocumentStatusTransitionParameterDtoConverter.FromInternal).ToArray();

        DocumentPermissionDto[] permissions =
            transition.Permissions.Select(DocumentPermissionDtoConverter.FromInternal).ToArray();

        var result = new DocumentStatusTransitionDetailedDto
        {
            Status = status,
            Type = type,
            Parameters = { parameters },
            Permissions = { permissions },
            DisplayName = transition.DisplayName
        };

        return result;
    }
}
