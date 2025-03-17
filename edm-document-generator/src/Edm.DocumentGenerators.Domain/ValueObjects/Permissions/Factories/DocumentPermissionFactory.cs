using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Permissions.Factories;

public static class DocumentPermissionFactory
{
    public static DocumentPermission CreateFrom(DocumentPermissionType type, Id<DocumentRole>[] roleIds, Id<DocumentAttribute>[] attributeIds)
    {
        var result = new DocumentPermission(type, roleIds, attributeIds);

        return result;
    }
}
