using Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions.Types;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions;

public sealed class DocumentPermissionBff
{
    public required DocumentPermissionTypeBff Type { get; init; }
    public required string[] RoleIds { get; init; }
    public required string[] AttributeIds { get; init; }
}
