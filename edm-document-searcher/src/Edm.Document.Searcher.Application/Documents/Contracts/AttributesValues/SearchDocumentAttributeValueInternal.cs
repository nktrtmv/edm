using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Booleans;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Dates;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Strings;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;

namespace Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;

[JsonDerivedType(typeof(SearchDocumentBooleanAttributeValueInternal))]
[JsonDerivedType(typeof(SearchDocumentStringAttributeValueInternal))]
[JsonDerivedType(typeof(SearchDocumentDateAttributeValueInternal))]
[JsonDerivedType(typeof(SearchDocumentReferenceAttributeValueInternal))]
[JsonDerivedType(typeof(SearchDocumentNumberAttributeValueInternal))]
[DebuggerDisplay("{ToDebugDisplay}")]
internal abstract class SearchDocumentAttributeValueInternal
{
    protected SearchDocumentAttributeValueInternal(SearchDocumentRegistryRoleInternal registryRole)
    {
        RegistryRole = registryRole;
    }

    public SearchDocumentRegistryRoleInternal RegistryRole { get; }

    private string ToDebugDisplay => JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
}
