using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Statuses;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions.Parameters;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions;

internal static class DocumentStatusTransitionTemplateBffConverter
{
    public static DocumentStatusTransitionPrototypeBff ToBff(DocumentStatusTransitionPrototypeDto dto)
    {
        DocumentPermissionBff[] permissions = dto.Permissions.Select(DocumentPermissionBffConverter.ToBff).ToArray();

        DocumentStatusTransitionParameterBff[] parameters = dto.Parameters.Select(DocumentStatusTransitionParameterBffConverter.FromDto).ToArray();

        var result = new DocumentStatusTransitionPrototypeBff
        {
            Id = dto.Id,
            Type = DocumentStatusTransitionTypeTemplateBffConverter.ToBff(dto.Type),
            From = DocumentStatusPrototypeBffConverter.ToBff(dto.From),
            To = DocumentStatusPrototypeBffConverter.ToBff(dto.To),
            Permissions = permissions,
            Parameters = parameters,
            DisplayName = dto.DisplayName
        };

        return result;
    }

    public static DocumentStatusTransitionPrototypeDto ToDto(DocumentStatusTransitionPrototypeBff bff)
    {
        DocumentPermissionDto[] permissions = bff.Permissions.Select(DocumentPermissionBffConverter.FromBff).ToArray();

        DocumentStatusTransitionParameterDto[] parameters = bff
            .Parameters
            .Select(DocumentStatusTransitionParameterBffConverter.ToDto)
            .ToArray();

        var result = new DocumentStatusTransitionPrototypeDto
        {
            Id = bff.Id,
            Type = DocumentStatusTransitionTypeTemplateBffConverter.ToDto(bff.Type),
            From = DocumentStatusPrototypeBffConverter.ToDto(bff.From),
            To = DocumentStatusPrototypeBffConverter.ToDto(bff.To),
            Permissions = { permissions },
            Parameters = { parameters },
            DisplayName = bff.DisplayName
        };

        return result;
    }
}
