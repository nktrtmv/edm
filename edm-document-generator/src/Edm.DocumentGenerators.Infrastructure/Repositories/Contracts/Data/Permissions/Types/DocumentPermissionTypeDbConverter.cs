using Edm.DocumentGenerators.Domain.ValueObjects.Permissions.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Permissions.Types;

internal static class DocumentPermissionTypeDbConverter
{
    internal static DocumentPermissionTypeDb FromDomain(DocumentPermissionType type)
    {
        DocumentPermissionTypeDb result = type switch
        {
            DocumentPermissionType.Edit => DocumentPermissionTypeDb.Edit,
            DocumentPermissionType.View => DocumentPermissionTypeDb.View,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentPermissionType ToDomain(DocumentPermissionTypeDb type)
    {
        DocumentPermissionType result = type switch
        {
            DocumentPermissionTypeDb.Edit => DocumentPermissionType.Edit,
            DocumentPermissionTypeDb.View => DocumentPermissionType.View,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
