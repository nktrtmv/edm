namespace Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Numbers;

public sealed class SearchDocumentNumberRegistryRoleTypeInternal : SearchDocumentRegistryRoleTypeInternal
{
    internal SearchDocumentNumberRegistryRoleTypeInternal(int precision)
    {
        Precision = precision;
    }

    internal int Precision { get; }
}
