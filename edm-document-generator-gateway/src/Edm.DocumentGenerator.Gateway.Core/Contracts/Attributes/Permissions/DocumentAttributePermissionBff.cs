using Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Permissions;

public sealed class DocumentAttributePermissionBff
{
    public required string StatusId { get; init; }
    public required DocumentPermissionBff[] Permissions { get; init; }
}
