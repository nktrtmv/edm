namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles.Types.Inheritors;

public sealed class DocumentReferenceRegistryRoleTypeBff : DocumentRegistryRoleTypeBff
{
    public required string ReferenceType { get; init; }
    public required ReferenceRegistryRoleDisplayTypeBff DisplayType { get; init; }
}

public enum ReferenceRegistryRoleDisplayTypeBff
{
    None = 0,
    Common = 1,
    Person = 2
}
