using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;

using Edm.Document.Searcher.Domain.Documents.Markers;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Document.Searcher.Domain.Documents;

[DebuggerDisplay("{ToDebugDisplay}")]
public sealed class SearchDocument
{
    internal SearchDocument(
        Id<SearchDocument> id,
        Id<SearchDocumentTemplate> templateId,
        DomainId domainId,
        SearchDocumentAttributeValue[] attributesValues,
        ConcurrencyToken<SearchDocument> concurrencyToken)
    {
        Id = id;
        TemplateId = templateId;
        DomainId = domainId;
        AttributesValues = attributesValues;
        ConcurrencyToken = concurrencyToken;
    }

    public Id<SearchDocument> Id { get; }
    public Id<SearchDocumentTemplate> TemplateId { get; }
    public DomainId DomainId { get; }
    public SearchDocumentAttributeValue[] AttributesValues { get; private set; }
    public ConcurrencyToken<SearchDocument> ConcurrencyToken { get; }

    private string ToDebugDisplay => JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

    internal void SetAttributesValues(SearchDocumentAttributeValue[] attributesValues)
    {
        AttributesValues = attributesValues;
    }
}
