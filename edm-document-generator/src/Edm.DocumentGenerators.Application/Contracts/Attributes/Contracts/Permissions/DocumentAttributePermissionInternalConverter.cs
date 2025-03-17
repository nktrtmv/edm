using Edm.DocumentGenerators.Application.Contracts.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.Permissions;

internal static class DocumentAttributePermissionInternalConverter
{
    internal static DocumentAttributePermissionInternal FromDomain(DocumentAttributePermission permission)
    {
        var statusId = IdConverterTo.ToString(permission.Status);

        DocumentPermissionInternal[] permissions = permission.Permissions.Select(DocumentPermissionInternalConverter.FromDomain).ToArray();

        var result = new DocumentAttributePermissionInternal(statusId, permissions);

        return result;
    }

    internal static DocumentAttributePermission ToDomain(DocumentAttributePermissionInternal permission)
    {
        Id<DocumentStatus> statusId = IdConverterFrom<DocumentStatus>.FromString(permission.StatusId);

        DocumentPermission[] permissions = permission.Permissions.Select(DocumentPermissionInternalConverter.ToDomain).ToArray();

        var result = new DocumentAttributePermission(statusId, permissions);

        return result;
    }
}
