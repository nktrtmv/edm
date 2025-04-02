using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentClassifiers;

internal static class DocumentClassifierSubsetBffDocumentCategoryConverter
{
    public static DocumentClassifierSubsetBffDocumentCategory ToBff(DocumentClassifierSubsetDtoDocumentCategory documentCategory)
    {
        DocumentClassifierSubsetBffDocumentType[] typesInternal = documentCategory
            .DocumentTypes
            .Select(DocumentClassifierSubsetBffDocumentTypeConverter.ToBff)
            .ToArray();

        var categoryInternal = new DocumentClassifierSubsetBffDocumentCategory
        {
            DocumentCategoryId = documentCategory.DocumentCategoryId,
            DocumentTypes = typesInternal
        };

        return categoryInternal;
    }

    public static DocumentClassifierSubsetDtoDocumentCategory FromBff(DocumentClassifierSubsetBffDocumentCategory category)
    {
        DocumentClassifierSubsetDtoDocumentType[] typesInternal = category
            .DocumentTypes
            .Select(DocumentClassifierSubsetBffDocumentTypeConverter.FromBff)
            .ToArray();

        var categoryInternal = new DocumentClassifierSubsetDtoDocumentCategory
        {
            DocumentCategoryId = category.DocumentCategoryId,
            DocumentTypes = { typesInternal }
        };

        return categoryInternal;
    }
}
