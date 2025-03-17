using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Booleans;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Dates;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Numbers;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.References;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types.Inheritors.Strings;

namespace Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types;

[JsonDerivedType(typeof(SearchDocumentStringRegistryRoleTypeInternal))]
[JsonDerivedType(typeof(SearchDocumentBooleanRegistryRoleTypeInternal))]
[JsonDerivedType(typeof(SearchDocumentDateRegistryRoleTypeInternal))]
[JsonDerivedType(typeof(SearchDocumentNumberRegistryRoleTypeInternal))]
[JsonDerivedType(typeof(SearchDocumentReferenceRegistryRoleTypeInternal))]
[DebuggerDisplay("{ToDebugDisplay}")]
public abstract class SearchDocumentRegistryRoleTypeInternal
{
    private string ToDebugDisplay => JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
}
