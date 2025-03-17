using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Permissions;

internal static class DocumentAttributePermissionBffConverter
{
    internal static DocumentAttributePermissionBff FromDto(DocumentAttributePermissionDto dto)
    {
        DocumentPermissionBff[] permissions = dto.Permissions.Select(DocumentPermissionBffConverter.ToBff).ToArray();

        var result = new DocumentAttributePermissionBff
        {
            StatusId = dto.StatusId,
            Permissions = permissions
        };

        return result;
    }

    internal static DocumentAttributePermissionDto ToDto(DocumentAttributePermissionBff bff)
    {
        DocumentPermissionDto[] permissions = bff.Permissions.Select(DocumentPermissionBffConverter.FromBff).ToArray();

        var result = new DocumentAttributePermissionDto
        {
            StatusId = bff.StatusId,
            Permissions = { permissions }
        };

        return result;
    }
}
