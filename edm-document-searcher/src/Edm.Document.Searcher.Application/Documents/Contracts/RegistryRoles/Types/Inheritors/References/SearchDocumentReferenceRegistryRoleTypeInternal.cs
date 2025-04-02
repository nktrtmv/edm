namespace Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.References;

public sealed class SearchDocumentReferenceRegistryRoleTypeInternal : SearchDocumentRegistryRoleTypeInternal
{
    internal SearchDocumentReferenceRegistryRoleTypeInternal(string referenceType)
    {
        ReferenceType = referenceType;
    }

    internal string ReferenceType { get; }
}
