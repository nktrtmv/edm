namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types.Inheritors.References;

public sealed record DocumentReferenceRegistryRoleTypeExternal(
    string ReferenceType,
    int DisplayType,
    List<DocumentParentReferenceRegistryRoleTypeExternal>? Parents) : DocumentRegistryRoleTypeExternal;

public sealed record DocumentParentReferenceRegistryRoleTypeExternal(string ReferenceType, string[] Values);
