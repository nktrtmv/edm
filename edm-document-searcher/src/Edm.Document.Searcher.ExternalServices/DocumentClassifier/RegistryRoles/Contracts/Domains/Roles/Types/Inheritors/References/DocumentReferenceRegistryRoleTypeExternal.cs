namespace Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.References;

public sealed class DocumentReferenceRegistryRoleTypeExternal : DocumentRegistryRoleTypeExternal
{
    public DocumentReferenceRegistryRoleTypeExternal(string referenceType)
    {
        ReferenceType = referenceType;
    }

    public string ReferenceType { get; }
}
