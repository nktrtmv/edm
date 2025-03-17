using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Permissions;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes.Contracts.Permissions;

internal static class DocumentAttributePermissionDbConverter
{
    internal static DocumentAttributePermissionDb FromDomain(DocumentAttributePermission permission)
    {
        var status = IdConverterTo.ToString(permission.Status);

        DocumentPermissionDb[] permissions = permission.Permissions.Select(DocumentPermissionDbConverter.FromDomain).ToArray();

        var result = new DocumentAttributePermissionDb
        {
            Status = status,
            Permissions = { permissions }
        };

        return result;
    }

    internal static DocumentAttributePermission ToDomain(DocumentAttributePermissionDb permission)
    {
        Id<DocumentStatus> status = IdConverterFrom<DocumentStatus>.FromString(permission.Status);

        DocumentPermission[] permissions = permission.Permissions.Select(DocumentPermissionDbConverter.ToDomain).ToArray();

        var result = new DocumentAttributePermission(status, permissions);

        return result;
    }
}
