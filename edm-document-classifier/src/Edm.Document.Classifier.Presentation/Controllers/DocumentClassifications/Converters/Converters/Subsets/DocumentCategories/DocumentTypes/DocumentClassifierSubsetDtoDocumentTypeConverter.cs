using Edm.Document.Classifier.Application.DocumentClassifications.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Converters.Subsets.DocumentCategories.DocumentTypes;

internal static class DocumentClassifierSubsetDtoDocumentTypeConverter
{
    internal static DocumentClassifierSubsetInternalDocumentType ToInternal(DocumentClassifierSubsetDtoDocumentType documentType)
    {
        string[] documentKinds = documentType.DocumentKindIds.ToArray();

        var result = new DocumentClassifierSubsetInternalDocumentType(documentType.DocumentTypeId, documentKinds);

        return result;
    }

    internal static DocumentClassifierSubsetDtoDocumentType FromInternal(DocumentClassifierSubsetInternalDocumentType documentType)
    {
        string[] documentKinds = documentType.DocumentKindIds.ToArray();

        var result = new DocumentClassifierSubsetDtoDocumentType
        {
            DocumentTypeId = documentType.DocumentTypeId,
            DocumentKindIds = { documentKinds }
        };

        return result;
    }
}
