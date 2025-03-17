using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Types.Inheritors.DisplayTypes;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Types.Inheritors;

public sealed class DocumentDateRegistryRoleTypeBff : DocumentRegistryRoleTypeBff
{
    public required DateRegistryRoleDisplayTypeBff DisplayType { get; init; }
}
