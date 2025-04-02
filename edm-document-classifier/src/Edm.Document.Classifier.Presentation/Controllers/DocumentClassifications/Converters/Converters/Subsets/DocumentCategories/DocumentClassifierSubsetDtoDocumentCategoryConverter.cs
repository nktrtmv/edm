using Edm.Document.Classifier.Application.DocumentClassifications.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Converters.Subsets.DocumentCategories.DocumentTypes;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Converters.Subsets.DocumentCategories;

internal static class DocumentClassifierSubsetDtoDocumentCategoryConverter
{
    internal static DocumentClassifierSubsetInternalDocumentCategory ToInternal(DocumentClassifierSubsetDtoDocumentCategory documentCategory)
    {
        DocumentClassifierSubsetInternalDocumentType[] documentTypes =
            documentCategory.DocumentTypes.Select(DocumentClassifierSubsetDtoDocumentTypeConverter.ToInternal).ToArray();

        var result = new DocumentClassifierSubsetInternalDocumentCategory(documentCategory.DocumentCategoryId, documentTypes);

        return result;
    }

    internal static DocumentClassifierSubsetDtoDocumentCategory FromInternal(DocumentClassifierSubsetInternalDocumentCategory documentCategory)
    {
        DocumentClassifierSubsetDtoDocumentType[] documentTypes =
            documentCategory.DocumentTypes.Select(DocumentClassifierSubsetDtoDocumentTypeConverter.FromInternal).ToArray();

        var result = new DocumentClassifierSubsetDtoDocumentCategory
        {
            DocumentCategoryId = documentCategory.Id,
            DocumentTypes = { documentTypes }
        };

        return result;
    }
}
