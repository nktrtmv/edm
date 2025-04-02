using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions.Types;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions;

internal static class DocumentPermissionBffConverter
{
    public static DocumentPermissionBff ToBff(DocumentPermissionDto dto)
    {
        string[] roleIds = dto.RoleIds.ToArray();

        string[] attributeIds = dto.AttributeIds.ToArray();

        var type = DocumentPermissionTypeBffConverter.ToBff(dto.Type);

        var result = new DocumentPermissionBff
        {
            RoleIds = roleIds,
            Type = type,
            AttributeIds = attributeIds
        };

        return result;
    }

    public static DocumentPermissionDto FromBff(DocumentPermissionBff bff)
    {
        var type = DocumentPermissionTypeBffConverter.FromBff(bff.Type);

        var result = new DocumentPermissionDto
        {
            RoleIds = { bff.RoleIds },
            AttributeIds = { bff.AttributeIds },
            Type = type
        };

        return result;
    }
}
