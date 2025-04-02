using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Kinds;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Types;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles;

public sealed class DocumentRegistryRoleBff
{
    public required string Id { get; init; }
    public required int EnumIntValue { get; init; }
    public required string DisplayName { get; init; }
    public required FilterSettingsBff FilterSettings { get; init; }
    public required RegistrySettingsBff RegistrySettings { get; init; }
    public required DocumentRegistryRoleTypeBff Type { get; init; }
    public required DocumentRegistryRoleKindBff Kind { get; init; }
}
