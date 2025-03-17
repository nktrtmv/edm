using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Types;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;

public static class DocumentStatusBffConverter
{
    public static DocumentStatusBff ToBff(DocumentStatusDto status)
    {
        var type = DocumentStatusTypeBffConverter.FromDto(status.Type);

        DocumentStatusParameterBff[] parameters = status.Parameters.Select(DocumentStatusParameterBffFromDtoConverter.FromDto).ToArray();

        var result = new DocumentStatusBff
        {
            Id = status.Id,
            Type = type,
            Parameters = parameters,
            SystemName = status.SystemName,
            DisplayName = status.DisplayName
        };

        return result;
    }

    public static DocumentStatusDto ToDto(DocumentStatusBff status)
    {
        var type = DocumentStatusTypeBffConverter.ToDto(status.Type);

        DocumentStatusParameterDto[] parameters = status.Parameters.Select(DocumentStatusParameterBffToDtoConverter.ToDto).ToArray();

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
}
