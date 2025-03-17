using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentClassifiers;

internal static class DocumentClassifierSubsetBffConverter
{
    public static DocumentClassifierSubsetBff ToBff(DocumentClassifierSubsetDto dto)
    {
        var categoryInternal =
            DocumentClassifierSubsetBffDocumentCategoryConverter.ToBff(dto.DocumentCategory);

        var subsetInternal = new DocumentClassifierSubsetBff
        {
            BusinessSegmentIds = dto.BusinessSegmentIds.ToArray(),
            DocumentCategory = categoryInternal
        };

        return subsetInternal;
    }

    public static DocumentClassifierSubsetDto FromBff(DocumentClassifierSubsetBff subsetInternal)
    {
        var categoryInternal =
            DocumentClassifierSubsetBffDocumentCategoryConverter.FromBff(subsetInternal.DocumentCategory);

        var subsetDto = new DocumentClassifierSubsetDto
        {
            BusinessSegmentIds = { subsetInternal.BusinessSegmentIds },
            DocumentCategory = categoryInternal
        };

        return subsetDto;
    }
}
