using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Permissions.Types;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Permissions;

internal static class DocumentPermissionDbConverter
{
    internal static DocumentPermissionDb FromDomain(DocumentPermission permission)
    {
        DocumentPermissionTypeDb type = DocumentPermissionTypeDbConverter.FromDomain(permission.Type);

        string[] roleIds = permission.RoleIds.Select(IdConverterTo.ToString).ToArray();

        string[] attributeIds = permission.AttributeIds.Select(IdConverterTo.ToString).ToArray();

        var result = new DocumentPermissionDb
        {
            Type = type,
            RoleIds = { roleIds },
            AttributeIds = { attributeIds }
        };

        return result;
    }

    internal static DocumentPermission ToDomain(DocumentPermissionDb permission)
    {
        DocumentPermissionType type = DocumentPermissionTypeDbConverter.ToDomain(permission.Type);

        Id<DocumentRole>[] roleIds = permission.RoleIds.Select(IdConverterFrom<DocumentRole>.FromString).ToArray();

        Id<DocumentAttribute>[] attributeIds = permission.AttributeIds.Select(IdConverterFrom<DocumentAttribute>.FromString).ToArray();

        DocumentPermission result = DocumentPermissionFactory.CreateFrom(type, roleIds, attributeIds);

        return result;
    }
}
