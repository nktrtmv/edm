using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Boolean;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Date;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Number;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Reference;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.String;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues;

[JsonDerivedType(typeof(DocumentBooleanAttributeValueExternal))]
[JsonDerivedType(typeof(DocumentStringAttributeValueExternal))]
[JsonDerivedType(typeof(DocumentNumberAttributeValueExternal))]
[JsonDerivedType(typeof(DocumentDateAttributeValueExternal))]
[JsonDerivedType(typeof(DocumentReferenceAttributeValueExternal))]
[DebuggerDisplay("{ToDebugDisplay}")]
public abstract class DocumentAttributeValueExternal(DocumentAttributeExternal attribute)
{
    public DocumentAttributeExternal Attribute { get; } = attribute;

    private string ToDebugDisplay => JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
}
