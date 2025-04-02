using Edm.DocumentGenerators.Application.Contracts.Permissions.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Permissions.Types;

internal static class DocumentPermissionTypeDtoConverter
{
    internal static DocumentPermissionTypeDto FromInternal(DocumentPermissionTypeInternal type)
    {
        DocumentPermissionTypeDto result = type switch
        {
            DocumentPermissionTypeInternal.Edit => DocumentPermissionTypeDto.Edit,
            DocumentPermissionTypeInternal.View => DocumentPermissionTypeDto.View,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentPermissionTypeInternal ToInternal(DocumentPermissionTypeDto type)
    {
        DocumentPermissionTypeInternal result = type switch
        {
            DocumentPermissionTypeDto.Edit => DocumentPermissionTypeInternal.Edit,
            DocumentPermissionTypeDto.View => DocumentPermissionTypeInternal.View,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
