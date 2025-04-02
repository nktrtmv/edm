namespace Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Numbers;

public sealed class DocumentNumberRegistryRoleTypeExternal : DocumentRegistryRoleTypeExternal
{
    public DocumentNumberRegistryRoleTypeExternal(int precision)
    {
        Precision = precision;
    }

    public int Precision { get; }
}
