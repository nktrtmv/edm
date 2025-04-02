using Edm.DocumentGenerators.Domain.ValueObjects.Permissions.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Contracts.Permissions.Types;

internal static class DocumentPermissionTypeInternalConverter
{
    internal static DocumentPermissionTypeInternal FromDomain(DocumentPermissionType type)
    {
        DocumentPermissionTypeInternal result = type switch
        {
            DocumentPermissionType.Edit => DocumentPermissionTypeInternal.Edit,
            DocumentPermissionType.View => DocumentPermissionTypeInternal.View,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentPermissionType ToDomain(DocumentPermissionTypeInternal type)
    {
        DocumentPermissionType result = type switch
        {
            DocumentPermissionTypeInternal.Edit => DocumentPermissionType.Edit,
            DocumentPermissionTypeInternal.View => DocumentPermissionType.View,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
