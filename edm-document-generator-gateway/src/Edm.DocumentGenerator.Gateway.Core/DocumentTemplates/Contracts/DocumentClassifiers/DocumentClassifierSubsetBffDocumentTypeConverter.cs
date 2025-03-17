using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentClassifiers;

internal static class DocumentClassifierSubsetBffDocumentTypeConverter
{
    public static DocumentClassifierSubsetBffDocumentType ToBff(DocumentClassifierSubsetDtoDocumentType type)
    {
        var result = new DocumentClassifierSubsetBffDocumentType
        {
            DocumentTypeId = type.DocumentTypeId,
            DocumentKindIds = type.DocumentKindIds.ToArray()
        };

        return result;
    }

    public static DocumentClassifierSubsetDtoDocumentType FromBff(DocumentClassifierSubsetBffDocumentType documentType)
    {
        var result = new DocumentClassifierSubsetDtoDocumentType
        {
            DocumentTypeId = documentType.DocumentTypeId,
            DocumentKindIds = { documentType.DocumentKindIds }
        };

        return result;
    }
}
