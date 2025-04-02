using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Types;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Statuses;

internal static class DocumentStatusPrototypeBffConverter
{
    public static DocumentStatusPrototypeBff ToBff(DocumentStatusPrototypeDto status)
    {
        var type = DocumentStatusTypeBffConverter.FromDto(status.Type);

        DocumentStatusParameterBff[] parameters = status.Parameters.Select(DocumentStatusParameterBffFromDtoConverter.FromDto).ToArray();

        var result = new DocumentStatusPrototypeBff
        {
            Id = status.Id,
            Type = type,
            Parameters = parameters,
            SystemName = status.SystemName,
            DisplayName = status.DisplayName
        };

        return result;
    }

    public static DocumentStatusPrototypeDto ToDto(DocumentStatusPrototypeBff status)
    {
        var type = DocumentStatusTypeBffConverter.ToDto(status.Type);

        DocumentStatusParameterDto[] parameters = status.Parameters.Select(DocumentStatusParameterBffToDtoConverter.ToDto).ToArray();

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
}
