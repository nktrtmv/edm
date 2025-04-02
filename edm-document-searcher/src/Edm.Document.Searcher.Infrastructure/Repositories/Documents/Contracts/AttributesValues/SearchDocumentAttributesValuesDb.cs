using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Booleans;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Dates;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Strings;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues;

internal sealed class SearchDocumentAttributesValuesDb
{
    public required SearchDocumentBooleanAttributeValueDb[] BooleanValues { get; init; }
    public required SearchDocumentDateAttributeValueDb[] DateValues { get; init; }
    public required SearchDocumentNumberAttributeValueDb[] NumberValues { get; init; }
    public required SearchDocumentReferenceAttributeValueDb[] ReferenceValues { get; init; }
    public required SearchDocumentStringAttributeValueDb[] StringValues { get; init; }
}
