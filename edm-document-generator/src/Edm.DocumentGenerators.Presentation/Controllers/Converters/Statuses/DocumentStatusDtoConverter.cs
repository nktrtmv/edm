using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Types;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses.Parameters;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses.Types;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses;

internal static class DocumentStatusDtoConverter
{
    internal static DocumentStatusDto FromInternal(DocumentStatusInternal status)
    {
        DocumentStatusTypeDto type = DocumentStatusTypeDtoConverter.FromInternal(status.Type);

        DocumentStatusParameterDto[] parameters = status.Parameters.Select(DocumentStatusParameterDtoFromInternalConverter.FromInternal).ToArray();

        var result = new DocumentStatusDto
        {
            Id = status.Id,
            Type = type,
            Parameters = { parameters },
            SystemName = status.SystemName,
            DisplayName = status.DisplayName
        };

        return result;
    }

    internal static DocumentStatusInternal ToInternal(DocumentStatusDto status)
    {
        DocumentStatusTypeInternal type = DocumentStatusTypeDtoConverter.ToInternal(status.Type);

        DocumentStatusParameterInternal[] parameters = status.Parameters.Select(DocumentStatusParameterDtoToInternalConverter.ToInternal).ToArray();

        var result = new DocumentStatusInternal(status.Id, type, parameters, status.SystemName, status.DisplayName);

        return result;
    }
}
