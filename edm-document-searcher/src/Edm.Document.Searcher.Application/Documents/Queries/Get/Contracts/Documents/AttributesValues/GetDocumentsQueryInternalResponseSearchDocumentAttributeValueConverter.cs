using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Boolean;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Date;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Number;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Reference;
using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.String;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Booleans;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Dates;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Numbers;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Strings;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues;

internal static class GetDocumentsQueryInternalResponseSearchDocumentAttributeValueConverter
{
    internal static GetDocumentsQueryInternalResponseSearchDocumentAttributeValue FromDomain(SearchDocumentAttributeValue attributeValue)
    {
        GetDocumentsQueryInternalResponseSearchDocumentAttributeValue result = attributeValue switch
        {
            SearchDocumentBooleanAttributeValue v =>
                GetDocumentsQueryInternalResponseSearchDocumentBooleanAttributeValueConverter.FromDomain(v),

            SearchDocumentDateAttributeValue v =>
                GetDocumentsQueryInternalResponseSearchDocumentDateAttributeValueConverter.FromDomain(v),

            SearchDocumentNumberAttributeValue v =>
                GetDocumentsQueryInternalResponseSearchDocumentNumberAttributeValueConverter.FromDomain(v),

            SearchDocumentReferenceAttributeValue v =>
                GetDocumentsQueryInternalResponseSearchDocumentReferenceAttributeValueConverter.FromDomain(v),

            SearchDocumentStringAttributeValue v =>
                GetDocumentsQueryInternalResponseSearchDocumentStringAttributeValueConverter.FromDomain(v),

            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }
}
