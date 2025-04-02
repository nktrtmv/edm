using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Kinds;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Types;

namespace Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles;

public sealed class SearchDocumentRegistryRole
{
    public SearchDocumentRegistryRole(int id, SearchDocumentRegistryRoleType type, SearchDocumentRegistryRoleKind kind)
    {
        Id = id;
        Type = type;
        Kind = kind;
    }

    public int Id { get; }
    public SearchDocumentRegistryRoleType Type { get; }
    public SearchDocumentRegistryRoleKind Kind { get; }
}
