using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions.Types;

internal static class DocumentPermissionTypeBffConverter
{
    public static DocumentPermissionTypeBff ToBff(DocumentPermissionTypeDto dto)
    {
        var result = dto switch
        {
            DocumentPermissionTypeDto.Edit => DocumentPermissionTypeBff.Edit,
            DocumentPermissionTypeDto.View => DocumentPermissionTypeBff.View,
            _ => throw new ArgumentTypeOutOfRangeException(dto)
        };

        return result;
    }

    public static DocumentPermissionTypeDto FromBff(DocumentPermissionTypeBff type)
    {
        var result = type switch
        {
            DocumentPermissionTypeBff.Edit => DocumentPermissionTypeDto.Edit,
            DocumentPermissionTypeBff.View => DocumentPermissionTypeDto.View,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
