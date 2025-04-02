using Edm.Document.Classifier.Application.DocumentClassifications.Queries.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Converters.Subsets;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications.Converters.Queries.Converters.DocumentClassifications;

internal static class DocumentClassificationReadModelInternalConverter
{
    internal static DocumentClassificationReadModelDto FromInternal(DocumentClassificationReadModelInternal classification)
    {
        DocumentClassifierSubsetDto classifierSubset =
            DocumentClassifierSubsetDtoConverter.FromInternal(classification.DocumentClassifierSubset);

        var result = new DocumentClassificationReadModelDto
        {
            DocumentTemplateId = classification.DocumentTemplateId,
            Name = classification.Name,
            ClassifierSubset = classifierSubset
        };

        return result;
    }
}
