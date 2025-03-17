using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;

using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Kinds;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types;

namespace Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;

[DebuggerDisplay("{ToDebugDisplay}")]
public sealed class SearchDocumentRegistryRoleInternal
{
    public SearchDocumentRegistryRoleInternal(
        int id,
        SearchDocumentRegistryRoleTypeInternal type,
        SearchDocumentRegistryRoleKindInternal kind)
    {
        Id = id;
        Type = type;
        Kind = kind;
    }

    public int Id { get; }

    /// <summary>
    ///     Ожидаемый тип на фронте
    /// </summary>
    public SearchDocumentRegistryRoleTypeInternal Type { get; }

    public SearchDocumentRegistryRoleKindInternal Kind { get; }

    private string ToDebugDisplay => JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
}
