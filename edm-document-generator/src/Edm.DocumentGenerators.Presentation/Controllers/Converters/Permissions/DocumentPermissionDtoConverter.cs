using Edm.DocumentGenerators.Application.Contracts.Permissions;
using Edm.DocumentGenerators.Application.Contracts.Permissions.Types;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Permissions.Types;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Permissions;

internal static class DocumentPermissionDtoConverter
{
    internal static DocumentPermissionDto FromInternal(DocumentPermissionInternal permission)
    {
        DocumentPermissionTypeDto type = DocumentPermissionTypeDtoConverter.FromInternal(permission.Type);

        string[] roleIds = permission.RoleIds.ToArray();

        string[] attributeIds = permission.AttributeIds.ToArray();

        var result = new DocumentPermissionDto
        {
            Type = type,
            RoleIds = { roleIds },
            AttributeIds = { attributeIds }
        };

        return result;
    }

    internal static DocumentPermissionInternal ToInternal(DocumentPermissionDto permission)
    {
        DocumentPermissionTypeInternal type = DocumentPermissionTypeDtoConverter.ToInternal(permission.Type);

        string[] roleIds = permission.RoleIds.ToArray();

        string[] attributeIds = permission.AttributeIds.ToArray();

        var result = new DocumentPermissionInternal(type, roleIds, attributeIds);

        return result;
    }
}
