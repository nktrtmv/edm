using Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Types;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Statuses;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses.Parameters;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses.Types;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes.Statuses;

internal static class DocumentStatusPrototypeDtoConverter
{
    internal static DocumentStatusPrototypeDto FromInternal(DocumentStatusPrototypeInternal status)
    {
        DocumentStatusTypeDto type = DocumentStatusTypeDtoConverter.FromInternal(status.Type);

        DocumentStatusParameterDto[] parameters = status.Parameters.Select(DocumentStatusParameterDtoFromInternalConverter.FromInternal).ToArray();

        var result = new DocumentStatusPrototypeDto
        {
            Id = status.Id,
            Type = type,
            Parameters = { parameters },
            SystemName = status.SystemName,
            DisplayName = status.DisplayName
        };

        return result;
    }

    internal static DocumentStatusPrototypeInternal ToInternal(DocumentStatusPrototypeDto status)
    {
        DocumentStatusTypeInternal type = DocumentStatusTypeDtoConverter.ToInternal(status.Type);

        DocumentStatusParameterInternal[] parameters = status.Parameters.Select(DocumentStatusParameterDtoToInternalConverter.ToInternal).ToArray();

        var result = new DocumentStatusPrototypeInternal(status.Id, type, parameters, status.SystemName, status.DisplayName);

        return result;
    }
}
