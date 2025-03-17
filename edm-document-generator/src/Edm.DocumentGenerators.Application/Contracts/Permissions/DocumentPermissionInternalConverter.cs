using Edm.DocumentGenerators.Application.Contracts.Permissions.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Permissions;

internal static class DocumentPermissionInternalConverter
{
    internal static DocumentPermissionInternal FromDomain(DocumentPermission permission)
    {
        DocumentPermissionTypeInternal type = DocumentPermissionTypeInternalConverter.FromDomain(permission.Type);

        string[] roleIds = permission.RoleIds.Select(IdConverterTo.ToString).ToArray();

        string[] attributeIds = permission.AttributeIds.Select(IdConverterTo.ToString).ToArray();

        var result = new DocumentPermissionInternal(type, roleIds, attributeIds);

        return result;
    }

    internal static DocumentPermission ToDomain(DocumentPermissionInternal permission)
    {
        DocumentPermissionType type = DocumentPermissionTypeInternalConverter.ToDomain(permission.Type);

        Id<DocumentRole>[] roleIds = permission.RoleIds.Select(IdConverterFrom<DocumentRole>.FromString).ToArray();

        Id<DocumentAttribute>[] attributeIds = permission.AttributeIds.Select(IdConverterFrom<DocumentAttribute>.FromString).ToArray();

        DocumentPermission result = DocumentPermissionFactory.CreateFrom(type, roleIds, attributeIds);

        return result;
    }
}
