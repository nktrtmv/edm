using Edm.Document.Classifier.Application.DocumentClassifications.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Converters.Subsets.DocumentCategories;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Converters.Subsets;

internal static class DocumentClassifierSubsetDtoConverter
{
    internal static DocumentClassifierSubsetInternal ToInternal(DocumentClassifierSubsetDto subset)
    {
        string[] businessSegmentIds = subset.BusinessSegmentIds.ToArray();

        DocumentClassifierSubsetInternalDocumentCategory documentCategory =
            DocumentClassifierSubsetDtoDocumentCategoryConverter.ToInternal(subset.DocumentCategory);

        var result = new DocumentClassifierSubsetInternal(businessSegmentIds, documentCategory);

        return result;
    }

    internal static DocumentClassifierSubsetDto FromInternal(DocumentClassifierSubsetInternal subset)
    {
        string[] businessSegmentIds = subset.BusinessSegmentIds.ToArray();

        DocumentClassifierSubsetDtoDocumentCategory documentCategory =
            DocumentClassifierSubsetDtoDocumentCategoryConverter.FromInternal(subset.DocumentCategory);

        var result = new DocumentClassifierSubsetDto
        {
            BusinessSegmentIds = { businessSegmentIds },
            DocumentCategory = documentCategory
        };

        return result;
    }
}
