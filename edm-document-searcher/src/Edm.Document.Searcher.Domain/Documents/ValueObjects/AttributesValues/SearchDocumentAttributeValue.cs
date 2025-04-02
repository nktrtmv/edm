using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Booleans;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Dates;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Strings;

namespace Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues;

[JsonDerivedType(typeof(SearchDocumentBooleanAttributeValue))]
[JsonDerivedType(typeof(SearchDocumentDateAttributeValue))]
[JsonDerivedType(typeof(SearchDocumentNumberAttributeValue))]
[JsonDerivedType(typeof(SearchDocumentReferenceAttributeValue))]
[JsonDerivedType(typeof(SearchDocumentStringAttributeValue))]
[DebuggerDisplay("{ToDebugDisplay}")]
public abstract class SearchDocumentAttributeValue(int registryRoleId)
{
    public int RegistryRoleId { get; } = registryRoleId;

    private string ToDebugDisplay => JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
}
