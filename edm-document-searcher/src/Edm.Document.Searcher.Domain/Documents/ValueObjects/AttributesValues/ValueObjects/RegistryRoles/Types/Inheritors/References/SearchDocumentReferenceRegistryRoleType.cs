namespace Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Types.Inheritors.References;

public sealed class SearchDocumentReferenceRegistryRoleType : SearchDocumentRegistryRoleType
{
    public SearchDocumentReferenceRegistryRoleType(string referenceType)
    {
        ReferenceType = referenceType;
    }

    public string ReferenceType { get; }
}
