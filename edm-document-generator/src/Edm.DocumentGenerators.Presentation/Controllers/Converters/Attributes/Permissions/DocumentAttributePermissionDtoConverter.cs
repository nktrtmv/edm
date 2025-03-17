using Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Permissions;
using Edm.DocumentGenerators.Application.Contracts.Permissions;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Permissions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes.Permissions;

internal static class DocumentAttributePermissionDtoConverter
{
    internal static DocumentAttributePermissionDto FromInternal(DocumentAttributePermissionInternal permission)
    {
        string statusId = permission.StatusId;

        DocumentPermissionDto[] permissions = permission.Permissions.Select(DocumentPermissionDtoConverter.FromInternal).ToArray();

        var result = new DocumentAttributePermissionDto
        {
            StatusId = statusId,
            Permissions = { permissions }
        };

        return result;
    }

    internal static DocumentAttributePermissionInternal ToInternal(DocumentAttributePermissionDto permission)
    {
        string? statusId = permission.StatusId;

        DocumentPermissionInternal[] permissions = permission.Permissions.Select(DocumentPermissionDtoConverter.ToInternal).ToArray();

        var result = new DocumentAttributePermissionInternal(statusId, permissions);

        return result;
    }
}
