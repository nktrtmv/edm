using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;

using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents.AttributesValues;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents;

[DebuggerDisplay("{ToDebugDisplay}")]
public sealed class GetAllDocumentsQueryResponseDocumentBff
{
    public required string Id { get; init; }
    public required GetAllDocumentsQueryResponseDocumentAttributeValueBff[] AttributesValues { get; init; }

    private string ToDebugDisplay => JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
}
